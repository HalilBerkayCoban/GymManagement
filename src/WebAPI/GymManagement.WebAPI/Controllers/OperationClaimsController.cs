using GymManagement.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using GymManagement.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using GymManagement.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using GymManagement.Infrastructure.Authentication.Dtos.OperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto createdOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createdOperationClaimDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto deletedOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deletedOperationClaimDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto updatedOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(updatedOperationClaimDto);
        }
    }
}
