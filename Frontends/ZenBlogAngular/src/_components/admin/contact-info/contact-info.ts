import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
import {ContactResponseDTO} from '../../../_models/Contacts/ContactResponseDTO';
import {ContactCreateDTO} from '../../../_models/Contacts/ContactCreateDTO';
import {ContactUpdateDTO} from '../../../_models/Contacts/ContactUpdateDTO';
import {Modal} from 'bootstrap';
import {ContactService} from '../../../_services/contact-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {DatePipe} from '@angular/common';
import {FormsModule} from '@angular/forms';

declare const alertify: any;

@Component({
  selector: 'contact-info',
  imports: [
    DatePipe,
    FormsModule
  ],
  templateUrl: './contact-info.html',
  styleUrl: './contact-info.css'
})
export class ContactInfo implements AfterViewInit {
  DTO: ContactResponseDTO[] = [];
  newDTO: ContactCreateDTO = new ContactCreateDTO();
  updateDTO: ContactUpdateDTO = new ContactUpdateDTO();
  errors: any[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private contactService: ContactService, private sweetalertService: SweetalertService) {
    this.get();
  }

  ngAfterViewInit(): void {
    if (this.createModal) {
      this.modalInstances.set(this.createModal, new Modal(this.createModal.nativeElement));
    }
    if (this.updateModal) {
      this.modalInstances.set(this.updateModal, new Modal(this.updateModal.nativeElement));
    }
  }

  get() {
    this.contactService.get().subscribe({
      next: res => {
        this.DTO = res.data
      },
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  create(form: any) {
    this.contactService.create(this.newDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Contact Created Successfully");
      },
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  onSelected(model: ContactUpdateDTO) {
    this.updateDTO = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.contactService.update(this.updateDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Contact Updated Successfully");
      },
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  async delete(id: string) {
    const confirmed = await this.sweetalertService.areYouSure();
    if (confirmed) {
      this.contactService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Contact Deleted Successfully");
        },
        error: err => {
          if (err.status === 400) {
            this.errors = err.error.errors;
          }
          for (let i = 0; i < err.error.errors.length; i++) {
            alertify.error(err.error.errors[i].errorMessage);
          }
        }
      });
    }
  }


  private forceCleanup() {
    document.body.classList.remove('modal-open');
    document.body.style.removeProperty('padding-right');
    const backdrops = document.getElementsByClassName('modal-backdrop');
    while (backdrops.length > 0) {
      backdrops[0].remove();
    }
  }
}
