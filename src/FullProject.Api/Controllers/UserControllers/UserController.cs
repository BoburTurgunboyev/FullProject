using FullProject.Aplication.UseCases.UserCase.Commands;
using FullProject.Aplication.UseCases.UserCase.Dtos;
using FullProject.Aplication.UseCases.UserCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullProject.Api.Controllers.UserControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateUser(UserDto userDto)
        {
            var user = new CreateUserCommand()
            {
                Name = userDto.Name,
                Age = userDto.Age,
                Password = userDto.Password,
            };
            await _mediator.Send(user);
            return Ok(userDto);
        }

        [HttpPut]

        public async ValueTask<IActionResult> UpdateUser(int Id, UserDto userDto)
        {
            var user = new UpdateUserCommand()
            {
                Id = Id,
                Name = userDto.Name,
                Age = userDto.Age,
                Password = userDto.Password,
            };
            await _mediator.Send(user);
            return Ok("updated");
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUser(int id)
        {
            var res = await _mediator.Send(new DeleteUserCommand() {  Id = id });
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUser()
        {
            var res = await _mediator.Send(new GetAllUserQuery());
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUser(int id)
        {
            var res =  await _mediator.Send(new GetByIdQuery() { Id = id });
            return Ok(res);
        }
    }
}
