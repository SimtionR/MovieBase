import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Connection, ConnectionPending, ResponsePending, ResponsePendingRequest } from './models';
@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  private connectionPath = environment.apiUrl + 'connection/';

  constructor(private http: HttpClient) { }

  sendConnectionPending(receiverId : number) : Observable<ConnectionPending>
  {
    return this.http.post<ConnectionPending>(this.connectionPath + `AddConnectionPending/${receiverId}`, receiverId);
  }

  getConnectionPendingById(connectionPendingId : number) : Observable<ConnectionPending>
  {
    return this.http.get<ConnectionPending>(this.connectionPath +`GetConnectionPendingById/${connectionPendingId}`);
  }

  getConnectionsPendingByProfile(profileId : number) : Observable<Array<ConnectionPending>>
  {
    return this.http.get<Array<ConnectionPending>>(this.connectionPath + `connectionPendingsByProfile/${profileId}`);
  }

  acceptConnectionPending(data: ResponsePendingRequest) : Observable<ResponsePending>
  {
    return this.http.post<ResponsePending>(this.connectionPath + `acceptPendingResponse`, data);
  }
  declineConnectionPending(data: ResponsePendingRequest) : Observable<ResponsePending>
  {
    return this.http.post<ResponsePending>(this.connectionPath + 'declinePendingResposne', data);
  }

  getConnectionsByProfile(profileId: number) : Observable<Array<Connection>>
  {
    return this.http.get<Array<Connection>>(this.connectionPath + `getConnectionsByProfileId/${profileId}`);
  }

  getConnectionById(connectionId: number) : Observable<Connection>
  {
    return this.http.get<Connection>(this.connectionPath + `getConnectionById/${connectionId}`);
  }

  getResponsePendingById(pendingResponseId: number) : Observable<ResponsePending>
  {
    return this.http.get<ResponsePending>(this.connectionPath+ `getResponsePendingById/${pendingResponseId}`)
  }

  getResponsePendingsByProfileId(profileId: number) : Observable<Array<ResponsePending>>
  {
    return this.http.get<Array<ResponsePending>>(this.connectionPath + `getResponsePendingsByProfileId/${profileId}`);
  }

  deleteConnectionById(connectionId: number) : Observable<boolean>
  {
    return this.http.delete<boolean>(this.connectionPath + `deleteConnectionById/${connectionId}`);
  }
  
}
