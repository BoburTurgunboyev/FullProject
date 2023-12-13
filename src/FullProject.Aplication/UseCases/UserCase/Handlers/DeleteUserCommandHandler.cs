using FullProject.Aplication.Absreaction;
using FullProject.Aplication.UseCases.UserCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.UseCases.UserCase.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IDbConnect _dbConnection;

        public DeleteUserCommandHandler(IDbConnect dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result  = await _dbConnection.users.FirstOrDefaultAsync(x =>  x.Id == request.Id);
            if (result == null)
            {
                return false;
            }

            _dbConnection.users.Remove(result); 
            var res = await _dbConnection.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
