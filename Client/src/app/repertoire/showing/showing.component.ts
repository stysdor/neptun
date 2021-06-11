import { Component, Input, OnInit } from '@angular/core';
import { IShowing } from '../../shared/models/showing';

@Component({
  selector: 'app-showing',
  templateUrl: './showing.component.html',
  styleUrls: ['./showing.component.css']
})
export class ShowingComponent implements OnInit {
  @Input() showing: IShowing;
  constructor() { }

  ngOnInit(): void {
  }

}
