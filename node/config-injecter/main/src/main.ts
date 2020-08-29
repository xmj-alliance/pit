import { Dirent, readdirSync, readFileSync } from "fs";
import { resolve } from "path";
import { parse } from "yaml";
import { Service } from "typedi";

import { AppConfig, IConfiguration } from "./models/config";
import merge from "./deepMerge";

@Service()
export class ConfigInjector implements IConfiguration {

  private configPath = resolve(__dirname, "./configs");

  private _config: AppConfig;
  public get config(): AppConfig {
    return this._config;
  }
  public set config(v: AppConfig) {
    this._config = v;
  }
  
  private envMap = new Map([
    ["YOUR", "your"],
    ["OWN", "own"],
    ["APP", "app"],
    ["CONFIG", "config"],
  ]);

  private loadENV = () => {
    let envConfig = {} as AppConfig;

    this.envMap.forEach((value, key) => {

      if (process.env[key]) {
        envConfig[value] = process.env[key];
      }

    })

    return envConfig;

  };

  private loadConfig = () => {

    let appConfig = {} as AppConfig;

    let configs: AppConfig[] = [];

    // get file list from configs folder (as {})
    
    let dirEntries: Dirent[];
    let fileNames: string[] = [];
    try {
      dirEntries = readdirSync(this.configPath, { withFileTypes: true });
      fileNames = dirEntries.filter(dirent => dirent.isFile())
                            .map(dirent => dirent.name);

    } catch (error) {
      console.warn(`Error locating configs folder. \n${error}`);
      return appConfig;
    }

    // read content from each file and store in an array
    for (let file of fileNames) {
      let configFileContent = ""; 
      try {
        configFileContent = readFileSync( resolve(`${this.configPath}/${file}`), "utf8");
      } catch (error) {
        console.warn(`Error loading config: ${file}`);
      }
      let config = parse(configFileContent);
      if (!config) {
        continue;
      }
      configs.push(config);
    }

    // TODO: priorities

    // combine configs to a single object
    if (configs.length > 0) {
      appConfig = configs.reduce((total, current) => {
        return merge(total, current);
      });
    }

    // combine with env config

    const envConfig = this.loadENV();

    appConfig = merge(appConfig, envConfig);

    return appConfig;
  };

  /**
   *  Config Injector
   */
  constructor() {
    this.config = this.loadConfig();
  }



}