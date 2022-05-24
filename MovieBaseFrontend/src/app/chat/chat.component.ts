import { Component, OnDestroy, OnInit } from '@angular/core';
import { SignalrService } from '../services/signalr.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit, OnDestroy {

  constructor(private signalrService: SignalrService) { }

  ngOnInit(): void {
    this.signalrService.startConnection();

    // setTimeout(() => {
    //   this.signalrService.askServerListener();
    //   this.signalrService.askServer();
    // }, 2000);

  }

  ngOnDestroy(): void {
    this.signalrService.hubConnection.off("askServerResponse");
  }

 

}
