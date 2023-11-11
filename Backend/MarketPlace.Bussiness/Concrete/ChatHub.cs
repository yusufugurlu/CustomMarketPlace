using MarketPlace.Bussiness.Abstract;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MarketPlace.Bussiness.Concrete
{
    [Authorize]
    public class ChatHub : Hub, IHubService
    {
        public static ConcurrentDictionary<int, List<string>> users { get; set; } = new();
        public async Task SendAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task sendToList(List<string> userList, string message)
        {
            await Clients.Users(userList).SendAsync("ReceiveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            var identity = (ClaimsIdentity)Context.User.Identity;
            if (identity != null)
            {
                var user = identity?.Claims?.Where(x => x.Type == ClaimTypes.PrimarySid).Select(x => x.Value)?.FirstOrDefault() ?? "0";
                if (user != "0")
                {
                    var userId = int.Parse(user);
                    users.TryGetValue(userId, out List<string> userConnection);
                    if (userConnection == null)
                    {
                        userConnection = new List<string>();
                    }
                    userConnection.Add(Context.ConnectionId);

                    users.TryAdd(userId, userConnection);
                }
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var identity = (ClaimsIdentity)Context.User.Identity;
            if (identity != null)
            {
                var user = identity?.Claims?.Where(x => x.Type == ClaimTypes.PrimarySid).Select(x => x.Value)?.FirstOrDefault() ?? "0";
                if (user != "0")
                {
                    var userId = int.Parse(user);
                    var userConection = users.GetValueOrDefault(userId);

                    if (userConection != null && userConection.Contains(Context.ConnectionId))
                    {
                        userConection.Remove(Context.ConnectionId);
                    }

                }
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
