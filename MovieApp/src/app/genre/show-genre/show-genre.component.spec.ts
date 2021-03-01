import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowGenreComponent } from './show-genre.component';

describe('ShowGenreComponent', () => {
  let component: ShowGenreComponent;
  let fixture: ComponentFixture<ShowGenreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowGenreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
