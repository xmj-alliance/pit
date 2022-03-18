import { IPipe } from "./interfaces";

export class BaseFlow<TOutput> {

  input: unknown;

  pipes: IPipe<unknown>[] = [];

  private connectPipes = async () => {

    let prevOutput: unknown = this.input;

    while (this.pipes.length > 0) {
      const pipe = this.pipes.shift() as IPipe<unknown>;
      pipe.input = prevOutput;
      prevOutput = await pipe.process();
    }

    return prevOutput;

  };

  start = async (): Promise<TOutput> => {
    return await this.connectPipes() as Promise<TOutput>;
  };

}