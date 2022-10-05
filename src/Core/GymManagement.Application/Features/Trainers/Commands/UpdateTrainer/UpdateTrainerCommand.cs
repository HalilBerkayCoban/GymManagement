using AutoMapper;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;

namespace GymManagement.Application.Features.Trainers.Commands.UpdateTrainer
{
    public class UpdateTrainerCommand: IRequest<UpdatedTrainerDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerCommand, UpdatedTrainerDto>
        {
            private readonly ITrainerRepository _trainerRepository;
            private readonly IMapper _mapper;
            private readonly TrainerBusinessRules _trainerBusinessRules;

            public UpdateTrainerCommandHandler(ITrainerRepository trainerRepository, IMapper mapper, TrainerBusinessRules trainerBusinessRules)
            {
                _trainerRepository = trainerRepository;
                _mapper = mapper;
                _trainerBusinessRules = trainerBusinessRules;
            }

            public async Task<UpdatedTrainerDto> Handle(UpdateTrainerCommand request, CancellationToken cancellationToken)
            {
                Trainer trainer = await _trainerRepository.GetAsync(i => i.Id == request.Id);
                await _trainerBusinessRules.TrainerShouldExistWhenRequested(trainer);

                trainer.FirstName = request.FirstName;
                trainer.LastName = request.LastName;
                trainer.Email = request.Email;
                trainer.Status = request.Status;
                trainer.Branch = request.Branch;
                trainer.PhoneNumber = request.PhoneNumber;
                trainer.DateOfBirth = request.DateOfBirth;

                Trainer updatedTrainer = await _trainerRepository.UpdateAsync(trainer);
                UpdatedTrainerDto updatedTrainerDto = _mapper.Map<UpdatedTrainerDto>(updatedTrainer);
                return updatedTrainerDto;
            }
        }
    }
}
