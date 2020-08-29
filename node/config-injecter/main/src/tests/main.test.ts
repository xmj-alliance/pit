import 'reflect-metadata';
import { Container, Service } from 'typedi';

import { ConfigInjector } from '../main';
import { IConfiguration } from '../models/config';

describe("Main Test", () => {

  test("Config contains example values", async () => {

    const exampleConfig = {
      your: "your",
      own: "own",
      app: "app",
      config: "config",
    }

    const configInjecter = Container.get<IConfiguration>(ConfigInjector);
    expect(configInjecter.config).toStrictEqual(exampleConfig);

  });

  test("Config contains ENV override", async () => {

    const override = "My";

    process.env.your = override;

    const configInjecter = Container.get<IConfiguration>(ConfigInjector);
    expect(configInjecter.config.your).toEqual(override);

  });

  test("Can be injected into a class", async () => {
    
    const exampleConfig = {
      your: "your",
      own: "own",
      app: "app",
      config: "config",
    }

    @Service()
    class Subject {

      configInjection: IConfiguration;

      /**
       * Subject class
       */
      constructor(
        _configInjection: ConfigInjector
      ) {
        this.configInjection = _configInjection;
      }
    }

    const subject = Container.get(Subject);
    expect(subject.configInjection.config).toStrictEqual(exampleConfig);

  });

});