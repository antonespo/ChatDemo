import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  sendUrl: string;
  receiveUrl: string;
  constructor(
    private http: HttpClient,
    ) {
      this.sendUrl = 'http://localhost:5000/chat/new';
      this.receiveUrl = 'http://localhost:5000/chat/all';

    }

  // Http send Message
  public async sendMessage(message) {
    return await this.http.post(this.sendUrl, message);
  }
  // Http receive Message
  public async receiveMessage() {
    return await this.http.get(this.receiveUrl).toPromise();
  }
}
