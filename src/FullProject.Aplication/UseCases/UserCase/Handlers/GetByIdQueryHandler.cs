using FullProject.Aplication.Absreaction;
using FullProject.Aplication.UseCases.UserCase.Queries;
using FullProject.Domain.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.UseCases.UserCase.Handlers
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, User>
    {
        private readonly IDbConnect _dbConnect;

        public GetByIdQueryHandler(IDbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<User> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbConnect.users.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result;
        }
    }
}
