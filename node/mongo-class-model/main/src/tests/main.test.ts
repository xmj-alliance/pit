import { Database } from "../main";
import { items } from "../models/item";
import { orders } from "../models/order";
import { users } from "../models/user";

describe("Main Test", () => {

  // jest.setTimeout(30000);

  let db: Database;

  beforeAll(async () => {
    db = new Database();
    const isConnected = await db.connect();
    
    if (!isConnected) {
      throw new Error("Failed to set up test DB. Network issue? Or perhaps you forget to provide your own config?");
    }
   
    return;

  });

  test("Cheer up", async () => {
    expect("😄").toEqual("😄");
  });

  test("Add a user", async () => {

    const newUserInfo = {
      dbname: "user-john",
      name: "John"
    }
    
    // add a user
    const newUser = await users.create(newUserInfo);

    expect(newUser._id).toBeTruthy();
    expect(newUser.dbname).toEqual(newUserInfo.dbname);

  });

  test("Add an item", async () => {

    const newItemInfo = {
      dbname: "item-goldenBiscuit",
      name: "Golden Biscuit",
      price: 98765,
    }
    
    // add an item
    const newItem = await items.create(newItemInfo);

    expect(newItem._id).toBeTruthy();
    expect(newItem.price).toEqual(newItemInfo.price);

  });

  test("Add an order", async () => {

    // add a user
    const newUser = await users.create({
      dbname: "user-bigbang",
      name: "Mom Bigbang"
    });

    // add an item
    const newItem = await items.create({
      dbname: "item-premiumCatFood",
      name: "Premium Cat Food",
      price: 65891,
    });

    const newOrderInfo = {
      userID: newUser._id,
      itemID: newItem._id,
      createDate: new Date(),
      isComplete: false,
    }
    
    // add an item
    const newOrder = await orders.create(newOrderInfo);

    expect(newOrder._id).toBeTruthy();
    expect(newOrder.isComplete).toEqual(newOrderInfo.isComplete);

  });

  afterAll(async () => {
    if (db && db.instance) {
      return await db.instance.connection.dropDatabase();
    }
  });

});