import { IMovie } from "./movie";


export interface IShowing {
  id: number;
  movie: IMovie;
  theatreName: string;
  showingDateTime: Date;
}
