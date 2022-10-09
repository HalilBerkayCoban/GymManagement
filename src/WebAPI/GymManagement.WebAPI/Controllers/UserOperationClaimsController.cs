using GymManagement.Application.Dtos.UserOperationClaim;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using GymManagement.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaims;
using GymManagement.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaims;
using GymManagement.Application.Features.UserOperationClaims.Query.GetAllUserOperationClaims;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto createdUserOperationClaimDto = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", createdUserOperationClaimDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deletedUserOperationClaimDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(updatedUserOperationClaimDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserOperationClaimsQuery getAllUserOperationClaimQuery)
        {
            UserOperationClaimListModel userOperationClaimListModel = await Mediator.Send(getAllUserOperationClaimQuery);
            return Ok(userOperationClaimListModel);
        }
    }
}
