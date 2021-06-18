import { newArray } from '@angular/compiler/src/util';
import { Component, Input, OnInit } from '@angular/core';
import { Showing } from '../../shared/models/showing';

@Component({
  selector: 'app-main-carousel',
  templateUrl: './main-carousel.component.html',
  styleUrls: ['./main-carousel.component.css']
})
export class MainCarouselComponent implements OnInit {
  @Input() todayShowing: Showing;
  @Input() tommorowShowing: Showing;

  constructor() { }

  ngOnInit(): void {
    console.log(this.todayShowing, this.tommorowShowing);
  }


}
