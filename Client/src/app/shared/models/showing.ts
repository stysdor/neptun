import { IMovie } from "./movie";


export interface IShowing {
  id: number;
  movie: IMovie;
  theatreId: number;
  showingDateTime: Date;

}
