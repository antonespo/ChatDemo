import { Component, OnInit } from '@angular/core';
import { ChatService } from './chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  public identity: string;
  public text: string;
  public message;
  constructor(
    public chatService: ChatService,
  ) { }

  ngOnInit() {
  }

  sendMessage() {
    this.message = {name: this.identity, text: this.text};
    console.log(this.message)
    this.chatService.receiveMessage();
    this.chatService.sendMessage(this.message);
  }

}
