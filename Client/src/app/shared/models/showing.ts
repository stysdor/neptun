import { IMovie } from "./movie";


export class Showing {
  id: number;
  movie: IMovie;
  theatreName: string;
  showingDateTime: Date;

  constructor(params: Partial<Showing> = {}) {
    this.showingDateTime = new Date(params.showingDateTime);
  }

}
