using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Sandbox.RestApi.SignalR
{
    public interface IHubClient
    {
        Task TriggerSync();
    }

    public class BasicHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ClientConnected", Context.ConnectionId);
        }

    }
}
