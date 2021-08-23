import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Http404ViewComponent } from './http404.view.component';

describe('Http404Component', () => {
  let component: Http404ViewComponent;
  let fixture: ComponentFixture<Http404ViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Http404ViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Http404ViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
