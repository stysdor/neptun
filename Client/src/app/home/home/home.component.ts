import { Component, OnInit } from '@angular/core';
import { Showing } from '../../shared/models/showing';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  comingShowing: Showing[];
  isMobile: boolean;


  constructor() {
  }

  ngOnInit(): void {
    this.isMobile = this.getIsMobile();
    window.onresize = () => {
      this.isMobile = this.getIsMobile();
    }
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
}
