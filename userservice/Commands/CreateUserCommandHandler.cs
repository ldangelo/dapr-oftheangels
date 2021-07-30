
using System;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Microsoft.Extensions.Logging;
using Domain.dao;
using Domain.Events;


namespace userservice.Commands
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {

        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly DaprClient _daprClient;
private readonly IMediator _mediator;

        private readonly String storeName = "statestore";

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, DaprClient daprClient,IMediator mediator)
        {
            _logger = logger;
            _daprClient = daprClient;
            _mediator = mediator;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancelationToken)
        {
            _logger.LogInformation("Handling create user command");

            await _daprClient.SaveStateAsync(storeName, request.user.id.ToString(), request.user);

            await _mediator.Publish(new UserCreatedEvent(request.user)).ConfigureAwait(false);

            return request.user;
        }
    }
}
