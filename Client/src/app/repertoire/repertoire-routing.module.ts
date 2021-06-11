import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RepertoireComponent } from './repertoire.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component: RepertoireComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class RepertoireRoutingModule { }
