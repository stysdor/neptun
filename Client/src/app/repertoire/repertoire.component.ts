import { Component, OnInit } from '@angular/core';
import { Showing } from '../shared/models/showing';
import { ShowingParams } from '../shared/models/showingParams';
import { ShowingService } from '../shared/services/showing.service';

@Component({
  selector: 'app-repertoire',
  templateUrl: './repertoire.component.html',
  styleUrls: ['./repertoire.component.css']
})
export class RepertoireComponent implements OnInit {

  showings: Showing[];
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
   
  }
}
