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
        private readonly ILogger _logger;
        private readonly DaprClient _dapr;
        private readonly UserContext _context;
        public UserProjectionController(ILogger logger, DaprClient dapr, UserContext context)
        {
            _logger = logger;
            _dapr = dapr;
            _context = context;
        }
        
        [Topic("pubsub", "userCreated")]
        public async Task<int> ProjectUser(UserCreatedEvent e)
        {
            _logger.LogInformation(@"Projecting user with {id}",e.user);
            var user = e.user;
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}