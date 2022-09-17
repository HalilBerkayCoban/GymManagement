using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _meditor;

        public MembersController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] CreateMemberCommand createMemberCommand)
        {
            CreatedMemberDto result = await _meditor.Send(createMemberCommand);
            return Created("", result);
        }
    }
}
