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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IDbConnect _dbConnection;

        public UpdateUserCommandHandler(IDbConnect dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbConnection.users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res is null)
                return false;
            res.Name = request.Name;
            res.Age = request.Age;  
            res.Password = request.Password;

            _dbConnection.users.Update(res);
            var result  = await _dbConnection.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
