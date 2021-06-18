import { Component, OnInit } from '@angular/core';
import { Showing } from '../../shared/models/showing';
import { ShowingService } from '../../shared/services/showing.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  todayShowing: Showing;
  tommorowShowing: Showing;
  isMobile: boolean;


  constructor(private showingService: ShowingService) {
  }

  ngOnInit(): void {
    this.isMobile = this.getIsMobile();
    window.onresize = () => {
      this.isMobile = this.getIsMobile();
    }

    this.getTodaysShowing();
    this.getTommorowsShowing();
  }

  getIsMobile() {
    const width = document.documentElement.clientWidth;
    console.log(width);
    const breakpoint = 360;
    if (width <= breakpoint) {
      return true;
    } else {
      return false;
    }
  }

  getTodaysShowing() {
    this.showingService.getTodaysShowing().subscribe(response => {
      this.todayShowing = response;
      console.log(this.todayShowing);
    }, error => {
      console.log(error);
    });
  }

  getTommorowsShowing() {
    this.showingService.getTommorowShowing().subscribe(response => {
      this.tommorowShowing = response;
      console.log(this.tommorowShowing);
    }, error => {
      console.log(error);
    });
  }
}
