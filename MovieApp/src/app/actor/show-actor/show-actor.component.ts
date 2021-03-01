import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { Router } from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-show-actor',
  templateUrl: './show-actor.component.html',
  styleUrls: ['./show-actor.component.css']
})
export class ShowActorComponent implements OnInit {

  constructor(private service:SharedService, private router:Router, private location:Location) { }

  ActorList:any=[]
  ModalTitle:string;
  ActivateAddEditActComp:boolean=false;
  act:any;
  public msg = "Successfully deleted";

  ngOnInit(): void {
    this.refreshActorList();
  }

  addClick(){
    this.act={
      id:0,
      fullname:""
    }
    this.ModalTitle="Add Actor";
    this.ActivateAddEditActComp=true;
  }

  editClick(item){
   
    this.act = item;
    this.ModalTitle="Edit Actor"
    this.router.navigate(['/actor', item.id]);
    this.ActivateAddEditActComp=true;

  }

  deleteClick(item){
    //this.router.navigate(['/genre', item.id]);
    if(confirm('Are you sure?'))
    {
      this.service.deleteActor(item, item.id).subscribe();
      alert(this.msg);
      this.refreshActorList();
    }

  }

  closeClick(){
    this.ActivateAddEditActComp=false;
    this.location.go('/actor');
    this.refreshActorList();
  }

  refreshActorList(){
    this.service.getActorList().subscribe(data=>{
      this.ActorList=data;
    });
  }
}
