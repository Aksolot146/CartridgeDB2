using EasyNetQ;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendCartridges.BackgroundServices
{
    public class UserRequest
    {
        public long Id { get; set; }

        public UserRequest(long id)
        {
            Id = id;
        }
    }

    public class UserResponce
    {
        public string Name { get; set; }

        public UserResponce() { }
    }

    public class UserEventHandler : BackgroundService
    {
        private readonly IBus _bus;

        public UserEventHandler(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.Rpc.RespondAsync<UserRequest, UserResponce>(ProcessUserRequest);

            throw new NotImplementedException();
        }

        private UserResponce ProcessUserRequest(UserRequest userRequest)
        {
            return new UserResponce() { Name = "Ipsum" };
        }
    }
}
