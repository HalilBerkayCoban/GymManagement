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
    public class MembersController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMember([FromBody] CreateMemberCommand createMemberCommand)
        {
            CreatedMemberDto result = await Mediator.Send(createMemberCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllMembers([FromQuery] PageRequest pageRequest)
        {
            GetAllMembersQuery getAllMembersQuery = new() { PageRequest = pageRequest };
            MemberListModel memberListModel = await Mediator.Send(getAllMembersQuery);
            return Ok(memberListModel);
        }

        [HttpPost("dynamic")]
        public async Task<IActionResult> GetAllMembersByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetAllMembersByDynamicQuery getAllMembersByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            MemberListModel memberListModel = await Mediator.Send(getAllMembersByDynamicQuery);
            return Ok(memberListModel);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMember([FromQuery] DeleteMemberCommand deleteMemberCommand)
        {
            DeletedMemberDto result = await Mediator.Send(deleteMemberCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberCommand updateMemberCommand)
        {
            UpdatedMemberDto result = await Mediator.Send(updateMemberCommand);
            return Ok(result);
        }
    }
}
