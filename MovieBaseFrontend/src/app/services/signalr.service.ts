import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalR';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  hubConnection: signalR.HubConnection;

  // ssSubjs = new Subject<any>();
  // ssObs(): Observable<any> {
  //   return this.ssSubjs.asObservable();
  // }

  constructor(private toastr: ToastrService) { }

  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7184/test', {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .build();

    this.hubConnection.start().then(() => 
    {
      console.log("hubConnectionStart");
      this.askServerListener();
      this.askServer();
    })
    .catch(err => console.log("Error while starting connection: " + err))
  }

  async askServer() {
    console.log("askServerStart");
    await this.hubConnection.invoke("askServer", "hi")
    .then(() => {
      console.log("askServer.then");
    })
    .catch(err => console.log(err));

    console.log("This is the final prompt");
  }

  askServerListener() {
    console.log("askServerListenerStart");
    this.hubConnection.on("askServerResponse", (someText) => {
      console.log("askServer.listener")
      this.toastr.success(someText);
    })
  }
}
