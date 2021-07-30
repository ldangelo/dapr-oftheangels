using System.Threading;
using System.Threading.Tasks;
using Domain.dao;
using MediatR;
using Dapr.Client;

namespace Domain.Events
{
    public class UserCreatedEvent: INotification
    {

        public User user { get; set; }

        public UserCreatedEvent(User user) {
            this.user = user;
        }
    }

    public class UserCreatedHandler: INotificationHandler<UserCreatedEvent> {
        private readonly IMediator _mediator;
        private readonly DaprClient _dapr;
        public UserCreatedHandler(IMediator mediator,DaprClient dapr) {
            _mediator = mediator;
            _dapr = dapr;
        }

        public Task Handle(UserCreatedEvent e, CancellationToken token) {
           return _dapr.PublishEventAsync<UserCreatedEvent>("pubsub","userCreated",e,token);
        }
    }
}