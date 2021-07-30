
using System;
using System.Collections.Generic;
using MediatR;
using Dapr.Client;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.dao;

public class GetUserQuery
{
    public class Query : IRequest<Task<ActionResult<User>>>
    {
        public Guid id { get; set; }

        public Query(Guid id)
        {
            this.id = id;
        }
    }

    public class Handler : RequestHandler<Query, Task<ActionResult<User>>>
    {
        private readonly DaprClient _daprClient;

        public Handler(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        protected async override Task<ActionResult<User>> Handle(Query request)
        {
            return await _daprClient.GetStateAsync<ActionResult<User>>("statestore", request.id.ToString());
        }
    }
}