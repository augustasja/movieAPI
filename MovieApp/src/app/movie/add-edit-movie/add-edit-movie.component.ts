import { Component, Input, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-movie',
  templateUrl: './add-edit-movie.component.html',
  styleUrls: ['./add-edit-movie.component.css']
})
export class AddEditMovieComponent implements OnInit {

  public msg = "Successfully updated";
  public addSuccess = 'Successfully added';

  constructor(private service:SharedService) { }

  @Input () movie:any;
  id:string;
  name:string;
  releaseDate:string;
  genreId:any;
  actors:any;

  ngOnInit(): void {
    this.id = this.movie.id;
    this.name = this.movie.name;
    this.releaseDate = this.movie.releaseDate;
    this.genreId = this.showGenreList();
    this.actors = this.showActorList();
  }

  addMovie(){
    var val = {id:this.id,
      name:this.name,
      releaseDate:this.releaseDate,
      genreId:this.genreId};
      // actors:this.actors};
      this.service.addMovie(val).subscribe();
      alert(this.addSuccess);
  }
  updateMovie(){
    var val = {id:this.id,
      name:this.name,
      releaseDate:this.releaseDate,
      genreId:this.genreId};
      // actors:this.actors};
      this.service.updateMovie(val, val.id).subscribe();
      alert(this.msg);
  }
  showGenreList(){
    this.service.getGenreList().subscribe(data=>{
      this.genreId=data;
    });
  }

  showActorList(){
    this.service.getActorList().subscribe(data=>{
      this.actors=data;
    });
  }

}
