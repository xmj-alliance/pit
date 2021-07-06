import { randomUUID } from "crypto";
import { IActorQuerySelector, IInputActor, IStoredActor } from "src/models/interfaces/actor.interface";
import { ICUDMessage } from "src/models/interfaces/message.interface";

export class ActorService {

  private actors: IStoredActor[] = [
    /* Disclaimer: The following artists are randomly generated. */
    {
      id: "36cb7641-300c-4631-9c9b-b2fbaf50fca1",
      dbname: "actor-maximilian",
      name: "Maximilian",
      description: "Maximilian was the most successful German-speaking actor in English-language films since Emil Jannings, the winner of the first Best Actor Academy Award.",
      talents: ["singing", "dancing", "basketball"],
    },
    {
      id: "36e02c7f-4af7-426f-b888-3f3e35035428",
      dbname: "actor-andrea",
      name: "Andrea",
      description: "Andrea was born on November 20, 1981 in Newcastle upon Tyne, Northumberland, England as Andrea Louise Riseborough.",
      talents: ["rap", "dancing", "violin"],
    },
    {
      id: "5d610854-f73a-436d-8bc6-352b9535df71",
      dbname: "actor-craig",
      name: "Craig",
      description: "Craig was born on October 25, 1971 in Chicago, Illinois, USA as Craig Phillip Robinson.",
      talents: ["singing", "dancing", "acrobat"],
    },
    {
      id: "354dd547-b67c-4936-b065-f62c678b17de",
      dbname: "actor-greer",
      name: "Greer",
      description: "Greer was born on September 29, 1904 in London, England, to Nancy Sophia (Greer) and George Garson, a commercial clerk.",
      talents: ["pop", "boating", "monolog"],
    },
    {
      id: "8b9eb30b-1700-45e9-ba23-d38bf1d61bfa",
      dbname: "actor-walter",
      name: "Walter",
      description: "Walter was best known for starring in many films which included Charade (1963), The Odd Couple (1968), Grumpy Old Men (1993), and Dennis the Menace (1993).",
      talents: ["camping", "poetry", "guitar"],
    },
  ];

  getSingle = async (selector: IActorQuerySelector): Promise<IStoredActor | null> => {

    let document: IStoredActor | null = null;

    if (selector.id) {
      document = this.actors.find(ele => ele.id === selector.id) || null;
    }

    if (selector.dbname) {
      document = this.actors.find(ele => ele.dbname === selector.dbname) || null;
    }

    return document;

  }

  getList = async (dbnames?: string[]): Promise<IStoredActor[]> => {

    if (!dbnames || dbnames.length <= 0) {
      return this.actors;
    }

    return this.actors.filter(ele => dbnames.includes(ele.dbname));
  
  };

  async addSingle(newItem: IInputActor): Promise<ICUDMessage> {

    this.actors.push({
      id: randomUUID(),
      dbname: newItem.dbname,
      name: newItem.name || "",
      description: newItem.description || "",
      talents: newItem.talents || [],
    });

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  }


  updateSingle = async (dbname: string, token: Partial<IStoredActor>): Promise<ICUDMessage> => {

    const index = this.actors.findIndex(ele => ele.dbname === dbname);

    if (index < 0) {
      return {
        ok: false,
        numAffected: 0,
        message: `Unable to find ${dbname}.`,
      }
    }

    this.actors[index] = {
      ...this.actors[index],
      ...token
    };

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  };
  
  deleteSingle = async (dbname: string): Promise<ICUDMessage> => {

    const index = this.actors.findIndex(ele => ele.dbname === dbname);

    if (index < 0) {
      return {
        ok: false,
        numAffected: 0,
        message: `Unable to find ${dbname}.`,
      }
    }

    this.actors.splice(index, 1);

    return {
      ok: true,
      numAffected: 1,
      message: "",
    }

  };

}