using Microsoft.AspNetCore.SignalR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(ChatMessage message)
        //{
        //    //await Clients.All.SendAsync("receiveMessage", message);

        //    await Clients.Clients(this.Context.ConnectionId).SendAsync("askServerResponse", message);
        //}
        public async Task askServer(string textFromClient)
        {
            string tempString;

            if(textFromClient == "hey")
            {
                tempString = "message was hey";
            }
            else
            {
                tempString = "message was smth else";
            }

            await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);


        }
    }
}
