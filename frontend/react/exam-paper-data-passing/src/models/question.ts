import { IChoice } from "./choice";

export interface IQuestion {
  id: string,
  type: string,
  title: string,
  score: number,
  choices: IChoice[],
  rightChoices?: IChoice[],
}
