import { randomUUID } from "crypto";
import { IInputDrama, IStoredDrama } from "src/models/interfaces/drama.interface";

import { ICUDMessage } from "src/models/interfaces/message.interface";

export class DramaService {

  private dramas: IStoredDrama[] = [
    /* Disclaimer: The following drama names are randomly generated. */
    {
      id: "36cb7641-300c-4631-9c9b-b2fbaf50fca1",
      dbname: "actor-snakeOfFreedom",
      name: "Snake Of Freedom",
      description: "The famous Snake Of Freedom trilogy.",
      genre: "fantasyComedy",
      actors: ["actor-maximilian", "actor-craig", "actor-walter"]
    },
    {
      id: "36e02c7f-4af7-426f-b888-3f3e35035428",
      dbname: "actor-lossOfTheEternal",
      name: "Loss Of The Eternal",
      description: "Fantasy adventure: Loss Of The Eternal",
      genre: "fantasyLove",
      actors: ["actor-andrea", "actor-greer", "actor-walter"]
    },
    {
      id: "5d610854-f73a-436d-8bc6-352b9535df71",
      dbname: "actor-TraitorsAndBearers",
      name: "Traitors And Bearers",
      description: "Guess what? This is a documentary.",
      genre: "scientificComedy",
      actors: ["actor-maximilian", "actor-craig", "actor-greer", "actor-walter"]
    },
  ];

  getSingle = async (dbname: string): Promise<IStoredDrama | null> => {

    const document = this.dramas.find(ele => ele.dbname === dbname);

    if (document) {
      return document;
    }

    return null;

  }

  getList = async (dbnames?: string[]): Promise<IStoredDrama[]> => {

    if (!dbnames || dbnames.length <= 0) {
      return this.dramas;
    }

    return this.dramas.filter(ele => dbnames.includes(ele.dbname));
  
  };

  async addSingle(newItem: IInputDrama): Promise<ICUDMessage> {

    this.dramas.push({
      id: randomUUID(),
      dbname: newItem.dbname,
      name: newItem.name || "",
      description: newItem.description || "",
      genre: newItem.genre,
      actors: newItem.actors || [],
    });

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  }


  updateSingle = async (dbname: string, token: Partial<IStoredDrama>): Promise<ICUDMessage> => {

    const index = this.dramas.findIndex(ele => ele.dbname === dbname);

    if (index < 0) {
      return {
        ok: false,
        numAffected: 0,
        message: `Unable to find ${dbname}.`,
      }
    }

    this.dramas[index] = {
      ...this.dramas[index],
      ...token
    };

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  };
  
  deleteSingle = async (dbname: string): Promise<ICUDMessage> => {

    const index = this.dramas.findIndex(ele => ele.dbname === dbname);

    if (index < 0) {
      return {
        ok: false,
        numAffected: 0,
        message: `Unable to find ${dbname}.`,
      }
    }

    this.dramas.splice(index, 1);

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  };

}