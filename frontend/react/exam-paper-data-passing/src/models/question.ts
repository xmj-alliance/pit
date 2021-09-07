export interface IQuestion {
  id: string,
  type: string,
  title: string,
  score: number,
  choices: string[], // Choice IDs
}