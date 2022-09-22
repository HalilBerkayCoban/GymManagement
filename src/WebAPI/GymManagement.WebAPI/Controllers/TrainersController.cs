using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Trainers.Commands.CreateTrainer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IMediator _meditor;

        public TrainersController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainerCommand createTrainerCommand)
        {
            CreatedTrainerDto result = await _meditor.Send(createTrainerCommand);
            return Created("", result);
        }
    }
}
