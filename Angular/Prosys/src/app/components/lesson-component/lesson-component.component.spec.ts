import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonComponentComponent } from './lesson-component.component';

describe('LessonComponentComponent', () => {
  let component: LessonComponentComponent;
  let fixture: ComponentFixture<LessonComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
