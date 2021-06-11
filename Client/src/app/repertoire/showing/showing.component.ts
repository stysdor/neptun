import { Component, Input, OnInit } from '@angular/core';
import { IShowing } from '../../shared/models/showing';

@Component({
  selector: 'app-showing',
  templateUrl: './showing.component.html',
  styleUrls: ['./showing.component.css']
})
export class ShowingComponent implements OnInit {
  @Input() showing: IShowing;

  day: string;
  hour: string;

  constructor() { }

  ngOnInit(): void {
    this.day = `${String(this.showing.showingDateTime.getDate()).padStart(2, "0")}.${String(this.showing.showingDateTime.getMonth()).padStart(2, "0")}`;
    this.hour = `${this.showing.showingDateTime.getHours()}:${String(this.showing.showingDateTime.getMinutes()).padStart(2, "0")}`;
  }

}
