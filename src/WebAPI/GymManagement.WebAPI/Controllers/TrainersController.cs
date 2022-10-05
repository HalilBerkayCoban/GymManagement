using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.Trainers.Commands.CreateTrainer;
using GymManagement.Application.Features.Trainers.Commands.DeleteTrainer;
using GymManagement.Application.Features.Trainers.Commands.UpdateTrainer;
using GymManagement.Application.Features.Trainers.Queries.GetAllTrainers;
using GymManagement.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainerCommand createTrainerCommand)
        {
            CreatedTrainerDto result = await Mediator.Send(createTrainerCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers([FromQuery] PageRequest pageRequest)
        {
            GetAllTrainersQuery getAllTrainersQuery = new() { PageRequest = pageRequest };
            TrainerListModel trainerListModel = await Mediator.Send(getAllTrainersQuery);
            return Ok(trainerListModel);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTrainer([FromQuery] DeleteTrainerCommand deleteMemberCommand)
        {
            DeletedTrainerDto result = await Mediator.Send(deleteMemberCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTrainer([FromBody] UpdateTrainerCommand updateMemberCommand)
        {
            UpdatedTrainerDto result = await Mediator.Send(updateMemberCommand);
            return Ok(result);
        }
    }
}
