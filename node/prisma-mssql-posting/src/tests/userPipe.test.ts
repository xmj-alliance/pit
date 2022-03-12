import { Prisma } from "prisma/generated/prisma-client-js";
import { DBContext } from "src/database/dbContext";
import { AddUserWithPostsPipe } from "src/pipes/user/addUserWithPosts";

describe("User pipe Test", () => {

  const dbContext = new DBContext();

  beforeAll(async () => {
    await dbContext.drop();
  });

  describe("User with some posts", () => {

    test("Add", async () => {

      const inputData: Prisma.UserCreateInput = {
        name: 'Alice',
        email: 'alice@prisma.io',
        posts: {
          createMany: {
            data: [
              { title: 'Hello World' },
              { title: 'Number 1 top' }
            ],
          },
        },
      };

      const addUserWithPostsPipe = new AddUserWithPostsPipe(inputData);

      const addedUser = await addUserWithPostsPipe.task;

      expect(addedUser.name).toEqual(inputData.name);
      expect(addedUser.posts.length).toEqual((inputData.posts?.createMany?.data as never[]).length);

    });

  });

  afterAll(async () => {
    await dbContext.disconnect();
  });

});
