import { Component, OnInit } from '@angular/core';
import { ChatService } from './chat.service';
import { HttpClient } from '@angular/common/http';

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
    public chatService: ChatService,private http: HttpClient,
  ) { }

  ngOnInit() {
  }

  sendMessage() {
    this.message = {name: this.identity, text: this.text};
    // console.log(this.message)
    console.log(this.chatService.receiveMessage());
    this.chatService.sendMessage(this.message);
  }

}
