export interface IInputDrama {
  dbname: string;
  name?: string;
  description?: string;
  genre: string;
  actors?: string[];
}

export interface IStoredDrama {
  id: string;
  dbname: string;
  name?: string | null;
  description?: string | null;
  genre: string;
  actors?: string[] | null;
}

export interface IDramaQuerySelector {
  id?: string,
  dbname?: string,
}

export interface IDramaQueryCondition {
  dbnames: string[]
}