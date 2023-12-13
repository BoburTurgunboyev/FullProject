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
    public class GetAllQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IDbConnect _dbConnect;

        public GetAllQueryHandler(IDbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbConnect.users.ToListAsync(cancellationToken);
            return result;
        }
    }
}
