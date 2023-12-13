using FullProject.Aplication.Absreaction;
using FullProject.Aplication.UseCases.UserCase.Commands;
using FullProject.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.UseCases.UserCase.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IDbConnect _dbConnect;

        public CreateUserCommandHandler(IDbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Age = request.Age,
                Password = request.Password,
            };

            _dbConnect.users.Add(user);
            var res = await _dbConnect.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
