import { Component, OnInit } from '@angular/core';
import { IShowing } from '../shared/models/showing';
import { ShowingParams } from '../shared/models/showingParams';
import { ShowingService } from '../shared/services/showing.service';

@Component({
  selector: 'app-repertoire',
  templateUrl: './repertoire.component.html',
  styleUrls: ['./repertoire.component.css']
})
export class RepertoireComponent implements OnInit {

  showings: IShowing[];
  showingParams = new ShowingParams();

  constructor(private showingService: ShowingService) { }

  ngOnInit(): void {
    console.log("Repertoire component work!");
    this.getShowings();
  }

  getShowings() {
    this.showingService.getShowings(this.showingParams).subscribe(response => {
      this.showings = response.data;
      this.showingParams.pageNumber = response.pageIndex;
      this.showingParams.pageSize = response.pageSize;
    }, error => {
      console.log(error);
    })
   /* const mockShowings: IShowing[] = [
      {
        id: 1,
        movie: { id: 1, title: "Title", description: "description", pictureUrl: "blabla", genres: [{ id: 1, name: "Action" }, {id: 2, name: "Dramat"}] },
        theatreId: 1,
        showingDateTime: new Date(2021, 6, 15, 18, 0, 0)
      },
      {
        id: 2,
        movie: { id: 1, title: "Title2", description: "description2", pictureUrl: "blabla", genres: [{ id: 1, name: "Action" }, { id: 2, name: "Dramat" }] },
        theatreId: 1,
        showingDateTime: new Date(2021, 6, 16, 18, 0, 0)
      }
    ]
    this.showings = mockShowings; */
  }
}
