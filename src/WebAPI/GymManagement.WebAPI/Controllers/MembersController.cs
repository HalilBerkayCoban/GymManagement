using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.Members.Queries.GetAllMembers;
using GymManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Application.Interfaces.Dynamic;
using GymManagement.Application.Features.Members.Queries.GetAllMembersByDynamic;
using GymManagement.Application.Features.Members.Commands.DeleteMember;
using GymManagement.Application.Features.Members.Commands.UpdateMember;

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

        [HttpPost("add")]
        public async Task<IActionResult> AddMember([FromBody] CreateMemberCommand createMemberCommand)
        {
            CreatedMemberDto result = await _meditor.Send(createMemberCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllMembers([FromQuery] PageRequest pageRequest)
        {
            GetAllMembersQuery getAllMembersQuery = new() { PageRequest = pageRequest };
            MemberListModel memberListModel = await _meditor.Send(getAllMembersQuery);
            return Ok(memberListModel);
        }

        [HttpPost("dynamic")]
        public async Task<IActionResult> GetAllMembersByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetAllMembersByDynamicQuery getAllMembersByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            MemberListModel memberListModel = await _meditor.Send(getAllMembersByDynamicQuery);
            return Ok(memberListModel);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMember([FromQuery] DeleteMemberCommand deleteMemberCommand)
        {
            DeletedMemberDto result = await _meditor.Send(deleteMemberCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberCommand updateMemberCommand)
        {
            UpdatedMemberDto result = await _meditor.Send(updateMemberCommand);
            return Ok(result);
        }
    }
}
