using System;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Domain.dao;
using Domain.Events;
using Microsoft.Extensions.Logging;
using Dapr;
using Projector.Repository;

namespace Projector.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Route("[controller]")]
    public class UserProjectionController : Controller
    {
        private readonly ILogger<UserProjectionController> _logger;
        private readonly DaprClient _dapr;
        private readonly UserContext _context;
        public UserProjectionController(ILogger<UserProjectionController> logger, DaprClient dapr, UserContext context)
        {
            _logger = logger;
            _dapr = dapr;
            _context = context;
        }
        
        [Topic("pubsub", "userCreated")]
        [HttpPost("/newUser")]
        public async Task<int> ProjectUser(User user)
        {
            try
            {
                _logger.LogDebug(@"Projecting user with {id}", user);
                var id = user.id;
                if (_context.Users.Any(e => e.id == id))
                {
                    _context.Users.Attach(user);
                }
                else
                {
                    _context.Add(user);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                _logger.LogError(ex.InnerException.Message);
                return -1;
            }
        }
    }
}