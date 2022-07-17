import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile/profile.service';
import { ChatService } from '../services/chat.service';
import { Message, Profile } from '../services/models';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  
  public profile: Profile;
  constructor(private chatService: ChatService,
    private profileService: ProfileService) { }

  ngOnInit(): void {
    this.profileService.getProfileByUserId().subscribe(p =>{
     
      this.profile = p
      console.log(p.userName);
    });
    this.chatService.retrieveMappedObject().subscribe( (receivedObj : Message) =>{
      this.addToInbox(receivedObj);
    });
  }

  message: Message = new Message();
  messageArray: Message[] = [];


  send() : void{
    this.message.user = this.profile.userName;
    console.log("here",this.message);
    if(this.message){
      if(this.message.user.length == 0 || this.message.text.length == 0){
        window.alert("Both fields are required!");
        return;
      } else {
        console.log(this.message);
        this.chatService.brodcastMessage(this.message);
      }
    }
  }

  addToInbox(obj : Message) {
    const newObj: Message = new Message();
    newObj.user = obj.user;
    newObj.text = obj.text;
    this.messageArray.push(newObj);
  };


 

}
