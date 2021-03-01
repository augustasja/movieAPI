import { Component, Input, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { Router } from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-show-movie',
  templateUrl: './show-movie.component.html',
  styleUrls: ['./show-movie.component.css']
})
export class ShowMovieComponent implements OnInit {

  constructor(private service:SharedService, private router:Router,
      private location:Location) { }

    @Input()
    search:string;

    MovieList:any[];
    MovActorList:any[];
    ModalTitle:string;
    ActivateAddEditMovieComp:boolean=false;
    movie:any;

    public msg = "Successfully deleted"

  ngOnInit(): void {
    this.refreshMovieList();
    this.refreshActorList();
  }

  addClick(){
    this.movie={
      id:0,
      name:"",
      releaseDate:"",
      genreId:0
      //actors:[]
      //actors prideti list veliau
    }
    this.ModalTitle="Add Movie";
    this.ActivateAddEditMovieComp=true;
  }

  editClick(item){
   
    this.movie = item;
    this.ModalTitle="Edit Movie"
    this.router.navigate(['/movie', item.id]);
    this.ActivateAddEditMovieComp=true;

  }

  deleteClick(item){
    //this.router.navigate(['/genre', item.id]);
    if(confirm('Are you sure?'))
    {
      this.service.deleteMovie(item, item.id).subscribe();
      alert(this.msg);
      this.refreshMovieList();
    }

  }

  closeClick(){
    this.ActivateAddEditMovieComp=false;
    this.location.go('/movie');
    this.refreshMovieList();
  }

  refreshMovieList(){
    this.service.getMovieList().subscribe(data=>{
      this.MovieList=data;
    });
  }
  refreshActorList(){
    this.service.getActorList().subscribe(data=>{
      this.MovActorList=data;
    });
  }

  searchMovieClick(){
    this.service.searchMovie(this.search).subscribe(data=>{
      this.MovieList=data;
    });
  }

}
