import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
import {MessageResponseDTO} from '../../../_models/Messages/MessageResponseDTO';
import {MessageCreateDTO} from '../../../_models/Messages/MessageCreateDTO';
import {MessageUpdateDTO} from '../../../_models/Messages/MessageUpdateDTO';
import {Modal} from 'bootstrap';
import {MessageService} from '../../../_services/message-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {DatePipe} from '@angular/common';
import {FormsModule} from '@angular/forms';

declare const alertify: any;
interface MessageWithIndex extends MessageResponseDTO {
  serialIndex?: number;
}

@Component({
  selector: 'app-message',
  imports: [
    DatePipe,
    FormsModule
  ],
  templateUrl: './message.html',
  styleUrl: './message.css'
})
export class Message implements AfterViewInit {
  DTO: MessageWithIndex[] = [];
  newDTO: MessageCreateDTO = new MessageCreateDTO();
  updateDTO: MessageUpdateDTO = new MessageUpdateDTO();
  errors: any[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private messageService: MessageService, private sweetalertService: SweetalertService) {
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
    this.messageService.get().subscribe({
      next: res => {
        let readCounter = 0;
        let unreadCounter = 0;

        this.DTO = res.data.map((item: MessageResponseDTO) => {
          const itemWithIndex: MessageWithIndex = item;
          if (item.isRead) {
            readCounter++;
            itemWithIndex.serialIndex = readCounter;
          } else {
            unreadCounter++;
            itemWithIndex.serialIndex = unreadCounter;
          }
          return itemWithIndex;
        });
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
    this.messageService.create(this.newDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Message Created Successfully");
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

  onSelected(model: MessageUpdateDTO) {
    this.updateDTO = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.messageService.update(this.updateDTO).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Message Updated Successfully");
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
      this.messageService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Message Deleted Successfully");
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
