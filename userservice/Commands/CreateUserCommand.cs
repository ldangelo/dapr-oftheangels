using MediatR;
using Domain.dao;

namespace userservice.Commands
{

    public class CreateUserCommand : IRequest<User>
    {
        public User user { get; set; }
    }
}
