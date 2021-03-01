import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditActorComponent } from './add-edit-actor.component';

describe('AddEditActorComponent', () => {
  let component: AddEditActorComponent;
  let fixture: ComponentFixture<AddEditActorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditActorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditActorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
