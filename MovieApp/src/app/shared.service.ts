import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  // Genre
  getGenreList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/genre');
  }

  addGenre(val:any){
    return this.http.post(this.APIUrl+'/genre', val);
  }

  updateGenre(val:any, id:any){
    return this.http.put(this.APIUrl+'/genre/'+id, val);
  }

  deleteGenre(val:any, id:any){
    return this.http.delete(this.APIUrl+'/genre/'+id, val)
  }
  //

  // Actor
  getActorList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/actor');
  }

  addActor(val:any){
    return this.http.post(this.APIUrl+'/actor', val);
  }

  updateActor(val:any, id:any){
    return this.http.put(this.APIUrl+'/actor/'+id, val);
  }

  deleteActor(val:any, id:any){
    return this.http.delete(this.APIUrl+'/actor/'+id, val)
  }
  //

  // Movie
  getMovieList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/movie');
  }

  addMovie(val:any){
    return this.http.post(this.APIUrl+'/movie', val);
  }

  updateMovie(val:any, id:any){
    return this.http.put(this.APIUrl+'/movie/'+id, val);
  }

  deleteMovie(val:any, id:any){
    return this.http.delete(this.APIUrl+'/movie/'+id, val)
  }

  searchMovie(val:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/movie/?search='+val);
  }
  //

}
