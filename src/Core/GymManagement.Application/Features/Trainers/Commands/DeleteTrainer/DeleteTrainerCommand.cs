using AutoMapper;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Trainers.Commands.DeleteTrainer
{
    public class DeleteTrainerCommand: IRequest<DeletedTrainerDto>
    {
        public int Id { get; set; }
        public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand, DeletedTrainerDto>
        {
            private readonly ITrainerRepository _trainerRepository;
            private readonly IMapper _mapper;
            private readonly TrainerBusinessRules _trainerBusinessRules;

            public DeleteTrainerCommandHandler(ITrainerRepository trainerRepository, IMapper mapper, TrainerBusinessRules trainerBusinessRules)
            {
                _trainerRepository = trainerRepository;
                _mapper = mapper;
                _trainerBusinessRules = trainerBusinessRules;
            }

            public async Task<DeletedTrainerDto> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
            {
                Trainer trainer = await _trainerRepository.GetAsync(i => i.Id == request.Id);
                await _trainerBusinessRules.TrainerShouldExistWhenRequested(trainer);
                Trainer deletedTrainer = await _trainerRepository.DeleteAsync(trainer);
                DeletedTrainerDto deletedTrainerDto = _mapper.Map<DeletedTrainerDto>(deletedTrainer);
                return deletedTrainerDto;
            }
        }
    }
}
