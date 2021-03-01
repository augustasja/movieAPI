import { Component, Input, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-add-edit-genre',
  templateUrl: './add-edit-genre.component.html',
  styleUrls: ['./add-edit-genre.component.css']
})
export class AddEditGenreComponent implements OnInit {

  public msg = "Successfully updated";
  public addSuccess = 'Successfully added';
  constructor(private service:SharedService) {  }

  @Input () gen:any;
  id:string;
  type:string;

  ngOnInit(): void {
    this.id=this.gen.id;
    this.type=this.gen.type;
  }

  addGenre(){
    var val = {id:this.id,
              type:this.type};
      this.service.addGenre(val).subscribe();
      alert(this.addSuccess);
  }

  updateGenre(){
    var val = {id:this.id,
      type:this.type};
  this.service.updateGenre(val, val.id).subscribe();
      alert(this.msg);
  }

}
