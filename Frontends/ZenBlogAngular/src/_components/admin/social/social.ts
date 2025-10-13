import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
import {SocialResponseDTO} from '../../../_models/Socials/SocialResponseDTO';
import {SocialCreateDTO} from '../../../_models/Socials/SocialCreateDTO';
import {SocialUpdateDTO} from '../../../_models/Socials/SocialUpdateDTO';
import {Modal} from 'bootstrap';
import {SocialService} from '../../../_services/social-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {DatePipe} from '@angular/common';
import {FormsModule} from '@angular/forms';

declare const alertify: any;

@Component({
  selector: 'social',
  imports: [
    DatePipe,
    FormsModule
  ],
  templateUrl: './social.html',
  styleUrl: './social.css'
})
export class Social implements AfterViewInit {
  DTO: SocialResponseDTO[] = [];
  newDTO: SocialCreateDTO = new SocialCreateDTO();
  updateDTO: SocialUpdateDTO = new SocialUpdateDTO();
  errors: any[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private socialService: SocialService, private sweetalertService: SweetalertService) {
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
    this.socialService.get().subscribe({
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
    this.socialService.create(this.newDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Social Created Successfully");
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

  onSelected(model: SocialUpdateDTO) {
    this.updateDTO = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.socialService.update(this.updateDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Social Updated Successfully");
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
      this.socialService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Social Deleted Successfully");
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
