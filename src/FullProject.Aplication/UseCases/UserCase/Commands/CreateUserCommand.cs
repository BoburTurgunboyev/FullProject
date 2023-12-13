using FullProject.Aplication.UseCases.UserCase.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.UseCases.UserCase.Commands
{
    public class CreateUserCommand:UserDto, IRequest<bool>
    {

    }
}
