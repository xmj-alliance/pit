import { Application, Router } from "./deps.ts";

import { APIController } from "./controllers/apiController.ts";

class App {
  private app = new Application();
  private host = "0.0.0.0";
  private port = 3000;
  private apiController = new APIController();
  private router = new Router();

  /** */
  constructor() {
    this.app.use((ctx) => {
      ctx.response.body = "Hello world!";
    });

    // activate readiness probe endpoint and subroutes
    this.router.use(
      "/api",
      this.apiController.router.routes(),
      this.apiController.router.allowedMethods(),
    );

    this.app.use(this.router.routes())
      .use(this.router.allowedMethods());

    console.log(`App: running on http://${this.host}:${this.port}`);
    this.app.listen(
      {
        hostname: this.host,
        port: this.port,
      },
    );
  }
}

export default new App();
