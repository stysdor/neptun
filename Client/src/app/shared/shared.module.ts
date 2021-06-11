import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CollapseModule,
    CarouselModule.forRoot()
  ],
  exports: [
    CollapseModule,
    CarouselModule
  ]
})
export class SharedModule { }
