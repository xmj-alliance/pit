import { oak } from "../deps.ts";

const { Router } = oak;

export class APIController {
  private _router = new Router();
  public get router(): oak.Router {
    return this._router;
  }
  /** */
  constructor() {
    this.router.get("/", (ctx) => {
      ctx.response.status = 200;
      ctx.response.body = {
        ok: true,
        message: "API works!",
      };
    });
  }
}
