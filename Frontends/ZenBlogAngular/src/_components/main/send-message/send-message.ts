import {Component} from '@angular/core';
import Swal from 'sweetalert2';
import {MessageService} from '../../../_services/message-service';
import {MessageCreateDTO} from '../../../_models/Messages/MessageCreateDTO';
import {FormsModule} from '@angular/forms';

declare const alertify: any;

@Component({
  selector: 'send-message',
  imports: [
    FormsModule
  ],
  templateUrl: './send-message.html',
  styleUrl: './send-message.css'
})
export class SendMessage {
  newMessage: MessageCreateDTO = new MessageCreateDTO();

  constructor(private messageService: MessageService
  ) {
  }


  sendMessage() {
    this.messageService.create(this.newMessage).subscribe({
      error: err => {
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      },
      complete: () => {
        Swal.fire({
          title: 'Message has been sent!',
          showCancelButton: false,
          icon: 'success'
        });

        setTimeout(() => {
          location.reload();
        }, 1000)
      }
    })
  }
}
