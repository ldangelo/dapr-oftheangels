
using System;
using System.Collections.Generic;
using MediatR;
using Dapr.Client;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.dao;
using Microsoft.Extensions.Logging;

public class GetUserQuery
{
    public class Query : IRequest<Task<ActionResult<User>>>
    {
        public Guid id { get; set; }

        public Query()
        {
        }
        
        public Query(Guid id)
        {
            this.id = id;
        }
    }

    public class Handler : RequestHandler<Query, Task<ActionResult<User>>>
    {
        private readonly DaprClient _daprClient;
        private ILogger<Handler> _logger;

        public Handler(DaprClient daprClient,ILogger<Handler> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        protected override async Task<ActionResult<User>> Handle(Query request)
        {
            try
            {
                return await _daprClient.GetStateAsync<ActionResult<User>>("statestore", request.id.ToString());
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.Message); 
               _logger.LogError(ex.StackTrace);
               _logger.LogError(ex.InnerException.Message);
               return null;
            }
        }
    }
}