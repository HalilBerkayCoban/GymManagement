using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.Trainers.Commands.CreateTrainer;
using GymManagement.Application.Features.Trainers.Commands.DeleteTrainer;
using GymManagement.Application.Features.Trainers.Commands.UpdateTrainer;
using GymManagement.Application.Features.Trainers.Queries.GetAllTrainers;
using GymManagement.Application.Requests;
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

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers([FromQuery] PageRequest pageRequest)
        {
            GetAllTrainersQuery getAllTrainersQuery = new() { PageRequest = pageRequest };
            TrainerListModel trainerListModel = await _meditor.Send(getAllTrainersQuery);
            return Ok(trainerListModel);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTrainer([FromQuery] DeleteTrainerCommand deleteMemberCommand)
        {
            DeletedTrainerDto result = await _meditor.Send(deleteMemberCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTrainer([FromBody] UpdateTrainerCommand updateMemberCommand)
        {
            UpdatedTrainerDto result = await _meditor.Send(updateMemberCommand);
            return Ok(result);
        }
    }
}
