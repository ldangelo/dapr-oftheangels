using System.Threading;
using System.Threading.Tasks;
using Domain.dao;
using MediatR;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace Domain.Events
{
    public class UserCreatedEvent: INotification
    {

        public User user { get; set; }

        public UserCreatedEvent(User user) {
            this.user = user;
        }
    }

    public class UserCreatedHandler: INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger _logger;
        private readonly DaprClient _dapr;
        public UserCreatedHandler(ILogger logger,DaprClient dapr)
        {
            _logger = logger;
            _dapr = dapr;
        }

        public Task Handle(UserCreatedEvent e, CancellationToken token) {
            _logger.LogDebug("Publishing userCreatedEvent");
            return _dapr.PublishEventAsync<UserCreatedEvent>("pubsub","userCreated",e,token);
        }
    }
}