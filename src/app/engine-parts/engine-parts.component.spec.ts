import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnginePartsComponent } from './engine-parts.component';

describe('EnginePartsComponent', () => {
  let component: EnginePartsComponent;
  let fixture: ComponentFixture<EnginePartsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EnginePartsComponent]
    });
    fixture = TestBed.createComponent(EnginePartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
