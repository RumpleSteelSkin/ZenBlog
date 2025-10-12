import {Component} from '@angular/core';
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import {ContactResponseDTO} from '../../../_models/Contacts/ContactResponseDTO';
import {ContactService} from '../../../_services/contact-service';
import {SendMessage} from '../send-message/send-message';

@Component({
  selector: 'app-contact-main',
  templateUrl: './contact-main.html',
  imports: [SendMessage],
  styleUrls: ['./contact-main.css']
})
export class ContactMain {

  contactInfos: ContactResponseDTO[] = [];
  safeUrl: SafeResourceUrl;

  constructor(
    private contactInfoService: ContactService,
    private sanitizer: DomSanitizer
  ) {
    this.getContactInfos();
  }

  getContactInfos() {
    this.contactInfoService.get().subscribe({
      next: result => {
        this.contactInfos = result.data.map(item => ({
          ...item,
          safeUrl: item.mapUrl
            ? this.sanitizer.bypassSecurityTrustResourceUrl(item.mapUrl)
            : null
        }));
      },
      error: err => console.log(err)
    });
  }

}
