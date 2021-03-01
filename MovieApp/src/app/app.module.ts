import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ActorComponent } from './actor/actor.component';
import { ShowActorComponent } from './actor/show-actor/show-actor.component';
import { AddEditActorComponent } from './actor/add-edit-actor/add-edit-actor.component';
import { GenreComponent } from './genre/genre.component';
import { ShowGenreComponent } from './genre/show-genre/show-genre.component';
import { AddEditGenreComponent } from './genre/add-edit-genre/add-edit-genre.component';
import { MovieComponent } from './movie/movie.component';
import { ShowMovieComponent } from './movie/show-movie/show-movie.component';
import { AddEditMovieComponent } from './movie/add-edit-movie/add-edit-movie.component';
import { SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    ActorComponent,
    ShowActorComponent,
    AddEditActorComponent,
    GenreComponent,
    ShowGenreComponent,
    AddEditGenreComponent,
    MovieComponent,
    ShowMovieComponent,
    AddEditMovieComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule,
    RouterModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
