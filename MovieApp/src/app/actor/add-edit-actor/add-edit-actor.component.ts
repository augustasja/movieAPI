import { Component, Input, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-actor',
  templateUrl: './add-edit-actor.component.html',
  styleUrls: ['./add-edit-actor.component.css']
})
export class AddEditActorComponent implements OnInit {

  public msg = "Successfully updated";
  public addSuccess = 'Successfully added';

  constructor(private service:SharedService) { }

  @Input () act:any;
  id:string;
  fullname:string;

  ngOnInit(): void {
    this.id=this.act.id;
    this.fullname=this.act.fullname;
  }
  addActor(){
    var val = {id:this.id,
              fullname:this.fullname};
      this.service.addActor(val).subscribe();
      alert(this.addSuccess);
  }
  updateActor(){
    var val = {id:this.id,
      fullname:this.fullname};
  this.service.updateActor(val, val.id).subscribe();
      alert(this.msg);
  }

}
