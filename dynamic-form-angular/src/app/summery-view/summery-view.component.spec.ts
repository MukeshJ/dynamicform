import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummeryViewComponent } from './summery-view.component';

describe('SummeryViewComponent', () => {
  let component: SummeryViewComponent;
  let fixture: ComponentFixture<SummeryViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SummeryViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SummeryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
