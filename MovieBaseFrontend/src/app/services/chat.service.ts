import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { async, Observable, Subject } from 'rxjs';
import {environment} from '../../environments/environment';
import { Message } from './models';
import {HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ChatService {

  // private connection : any =
  //  new signalR.HubConnectionBuilder().withUrl(environment.apiUrl+'chatsocket').
  //  configureLogging(signalR.LogLevel.Information)
  //  .build();
  // private connection : any =
  // new signalR.HubConnectionBuilder().withUrl(environment.apiUrl+'chatsocket').
  // configureLogging(signalR.LogLevel.Information)
  // .build();
  private connection: any  = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Debug)
    .withUrl(environment.apiUrl +'chatsocket', {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .build();

  private sendUrl = environment.apiUrl + 'chat/send';

  private receivedMessageObject : Message = new Message();
  private sahredObj = new Subject<Message>();

  constructor(private http: HttpClient) { 
    this.connection.onclose(async () => {
      await this.start();
    });

    this.connection.on("ReceiveOne", (user: string, text: string) => {this.mapReceivedMessage(user, text); });
    this.start();
  }


  public async start(){
    try{
      await this.connection.start();
      console.log("connected");
    } catch (err){
      console.log(err);
      setTimeout(() => this.start(), 5000);
    }
  }

  private mapReceivedMessage(user: string, text: string) : void {
    this.receivedMessageObject.user = user;
    this.receivedMessageObject.text = text;
    this.sahredObj.next(this.receivedMessageObject);
  }

  public brodcastMessage(text : any){
    this.http.post(this.sendUrl, text).subscribe( data => console.log(data));
  }

  public retrieveMappedObject(): Observable<Message> {
    return this.sahredObj.asObservable();
  }



}
