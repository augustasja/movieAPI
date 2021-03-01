import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { Router } from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-show-genre',
  templateUrl: './show-genre.component.html',
  styleUrls: ['./show-genre.component.css']
})
export class ShowGenreComponent implements OnInit {

  constructor(private service:SharedService, private router:Router, private location:Location) { }

  GenreList:any=[]
  ModalTitle:string;
  ActivateAddEditGenComp:boolean=false;
  gen:any;
  public msg = "Successfully deleted";
  ngOnInit(): void {
    this.refreshGenreList();
  }

  addClick(){
    this.gen={
      id:0,
      type:""
    }
    this.ModalTitle="Add Genre";
    this.ActivateAddEditGenComp=true;
  }

  editClick(item){
   
    this.gen = item;
    this.ModalTitle="Edit Genre"
    this.router.navigate(['/genre', item.id]);
    this.ActivateAddEditGenComp=true;

  }

  deleteClick(item){
    //this.router.navigate(['/genre', item.id]);
    if(confirm('Are you sure?'))
    {
      this.service.deleteGenre(item, item.id).subscribe();
      alert(this.msg);
      this.refreshGenreList();
    }

  }

  closeClick(){
    this.ActivateAddEditGenComp=false;
    this.location.go('/genre');
    this.refreshGenreList();
  }

  refreshGenreList(){
    this.service.getGenreList().subscribe(data=>{
      this.GenreList=data;
    });
  }


}
