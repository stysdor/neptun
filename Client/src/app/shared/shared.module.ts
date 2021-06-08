import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    CollapseModule,
    CarouselModule.forRoot()
  ],
  exports: [
    BrowserAnimationsModule,
    CollapseModule,
    CarouselModule
  ]
})
export class SharedModule { }
