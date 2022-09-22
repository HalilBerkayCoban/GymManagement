using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Features.Members.Models;
using GymManagement.Application.Features.Members.Queries.GetAllMembers;
using GymManagement.Application.Requests;
using GymManagement.Application.Interfaces.Repositories;
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

        [HttpGet]
        public async Task<IActionResult> GetAllMembers([FromQuery] PageRequest pageRequest)
        {
            GetAllMembersQuery getAllMembersQuery = new() {PageRequest = pageRequest};
            MemberListModel memberListModel = await _meditor.Send(getAllMembersQuery);
            return Ok(memberListModel);
        }
    }
}
