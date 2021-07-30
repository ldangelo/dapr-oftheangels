using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using userservice.Commands;
using System;
using Domain.dao;

namespace userservice.Controllers {
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Route("[controller]")]
    public class UserController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger<UserController> _logger;

        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id) {
            try {
                return await _mediator.Send(new GetUserQuery.Query(id)).Result;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<User>> Post(User u) {
            _logger.LogInformation("Creating user");

            try {
                return await _mediator.Send(new CreateUserCommand
                {
                    user = u
                });
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}