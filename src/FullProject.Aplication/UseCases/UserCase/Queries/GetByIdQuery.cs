using FullProject.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.UseCases.UserCase.Queries
{
    public class GetByIdQuery:IRequest<User>
    {
        public int Id { get; set; } 
    }
}
