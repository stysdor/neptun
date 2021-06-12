import { IGenre } from "./genre";

export interface IMovie {
  id: number;
  title: string;
  description: string;
  pictureUrl: string;
  genres: string[];
}
