import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogSlotComponent } from './dialog-slot.component';

describe('DialogSlotComponent', () => {
  let component: DialogSlotComponent;
  let fixture: ComponentFixture<DialogSlotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogSlotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogSlotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
