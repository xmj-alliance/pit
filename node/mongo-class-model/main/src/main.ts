import { connect, Mongoose } from "mongoose";
import { DBConfigs, IDBConnection } from "./models/dbConnection";
import * as dbConfigs from "./configs/example.json"; // But load your own config file via "readFileSync()" in your own project!

export class Database implements IDBConnection {
  instance: Mongoose | null = null;

  private configs = {} as DBConfigs;

  private uri = "";

  connect = async () => {

    try {

      console.log(`💿 DB: Establishing connection to ${ this.configs.dataDB }@${ this.configs.host }...`);
      
      this.instance = await connect(this.uri, {
        useCreateIndex: true,
        useNewUrlParser: true,
        useFindAndModify: false,
        useUnifiedTopology: true
      });

      console.log(`📀 DB: ${ this.configs.dataDB }@${ this.configs.host } is now online `);

      return true;
      
    } catch (error) {
      console.log(`😧 DB: We are having trouble reaching ${ this.configs.dataDB }@${ this.configs.host }: \n ${error.message}`);
    }

    return false;
  };

  /**
   *  Database
   *  Note: DB won't auto connect by default
   *  Note: In your project, configs should be injected or loaded.
   */
  constructor() {
    
    this.configs = dbConfigs;

    this.uri = `
      mongodb://${ this.configs.user }
      :${ this.configs.password }
      @${ this.configs.host }
      /${ this.configs.dataDB }
      ?authSource=${ this.configs.authDB }
    `;

    // remove all white spaces
    this.uri = this.uri.replace(/\s+/g, '');

  }

}