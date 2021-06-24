import "reflect-metadata";
import { IndexGraph } from "src/controllers/graphs/indexGraph";

class App {

  private indexGraph = new IndexGraph();

  // private app = new Koa();
  // private _gqlServer = (new IndexGraph()).server;
  // private server: Server;

  // private report = () => {
  //   const { address, port } = this.server.address() as AddressInfo;
  //   console.log(`🎧 App: mim is listening on http://${address}:${port}/`);
  // };

  // /**
  //  *
  //  */
  // constructor(

  // ) {

  //   this.app.use(logger());
  //   this.app.use(cors());

  //   // activate graphQL endpoint
  //   this.gqlServer.applyMiddleware(
  //     {
  //       app: this.app,
  //       path: `/gql`
  //     }
  //   )

  //   // Listen
  //   this.server = createServer(this.app.callback())
  //     .listen(
  //       this.configContainer.config.koa.port,
  //       this.configContainer.config.koa.host,
  //       this.report
  //     )

  // }

  /**
   *
   */
  constructor() {

    this.indexGraph.schema.then((data: any) => {
      console.log(data);
    });
  }

}

export default new App();