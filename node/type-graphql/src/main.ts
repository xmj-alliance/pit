import "reflect-metadata";
import { createServer, Server } from "http";
import { AddressInfo } from "net";

import Koa from "koa";
import logger from "koa-logger";
import cors from "@koa/cors";

import { IndexGraph } from "src/controllers/graphs/indexGraph";


class App {

  private app = new Koa();
  private gqlServer = (new IndexGraph()).server;
  private server: Server;

  private report = () => {
    const { address, port } = this.server.address() as AddressInfo;
    console.log(`🎧 App: app is listening on http://${address}:${port}/`);
  };

  /**
   *
   */
  constructor(

  ) {

    this.app.use(logger());
    this.app.use(cors());

    // activate graphQL endpoint
    this.gqlServer.applyMiddleware(
      {
        app: this.app,
        path: `/gql`
      }
    )

    // Listen
    this.server = createServer(this.app.callback())
      .listen(
        3000,
        "0.0.0.0",
        this.report
      )

  }

}

export default new App();