import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveCancelComponent } from './save-cancel.component';

describe('SaveCancelComponent', () => {
  let component: SaveCancelComponent;
  let fixture: ComponentFixture<SaveCancelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaveCancelComponent]
    });
    fixture = TestBed.createComponent(SaveCancelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
