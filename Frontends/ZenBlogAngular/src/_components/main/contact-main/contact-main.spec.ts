import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactMain } from './contact-main';

describe('ContactMain', () => {
  let component: ContactMain;
  let fixture: ComponentFixture<ContactMain>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContactMain]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContactMain);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
