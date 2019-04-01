using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace NTT.Backend.API
{
    public class NotificaHub : Hub
    {
        public Task NotificaServerTodos(string message)
        {
            return Clients.All.SendAsync("EnviarClientesTodos", message);
        }
    }
}
