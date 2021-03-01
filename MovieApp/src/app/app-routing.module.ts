import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import {GenreComponent} from './genre/genre.component';
import {ActorComponent} from './actor/actor.component';
import {MovieComponent} from './movie/movie.component';
import {AboutComponent} from './about/about.component';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


export const routes: Routes = [

{path:'genre', component:GenreComponent},
{path:'genre/:id', component: GenreComponent},
{path:'movie', component:MovieComponent},
{path:'movie/:id', component: MovieComponent},
{path:'actor', component:ActorComponent},
{path:'actor/:id', component:ActorComponent},
{path: 'about', component:AboutComponent}

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
