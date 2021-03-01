import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowActorComponent } from './show-actor.component';

describe('ShowActorComponent', () => {
  let component: ShowActorComponent;
  let fixture: ComponentFixture<ShowActorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowActorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowActorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
