import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Blogdetails } from './blogdetails';

describe('Blogdetails', () => {
  let component: Blogdetails;
  let fixture: ComponentFixture<Blogdetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Blogdetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Blogdetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
