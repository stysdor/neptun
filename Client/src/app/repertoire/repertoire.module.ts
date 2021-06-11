import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RepertoireComponent } from './repertoire.component';
import { ShowingComponent } from './showing/showing.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { SharedModule } from '../shared/shared.module';
import { RepertoireRoutingModule } from './repertoire-routing.module';



@NgModule({
  declarations: [RepertoireComponent, ShowingComponent, MovieDetailComponent],
  imports: [
    CommonModule,
    SharedModule,
    RepertoireRoutingModule
  ]
})
export class RepertoireModule { }
