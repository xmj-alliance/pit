import { DBContext } from "src/database/dbContext";

describe("Cheer Up Test", () => {

  const dbContext = new DBContext();

  describe("Make it happy", () => {
    test("Load happiness", async () => {
      expect('😊').toEqual('😊');
    });
  });

  afterAll(async () => {
    await dbContext.drop();
    await dbContext.disconnect();
  });

});
