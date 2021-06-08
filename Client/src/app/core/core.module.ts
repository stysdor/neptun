import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SharedModule } from '../shared/shared.module';
import { HeaderComponent } from './header/header.component';
import { MainCarouselComponent } from './main-carousel/main-carousel.component';




@NgModule({
  declarations: [NavBarComponent, HeaderComponent, MainCarouselComponent],
  imports: [
    CommonModule,
    SharedModule,
   
  ],
  exports: [
    NavBarComponent,
    HeaderComponent,
    MainCarouselComponent
  ]
})
export class CoreModule { }
