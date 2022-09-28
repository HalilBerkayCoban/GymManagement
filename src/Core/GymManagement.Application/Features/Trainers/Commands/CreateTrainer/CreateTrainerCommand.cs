using AutoMapper;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Trainers.Commands.CreateTrainer
{
    public class CreateTrainerCommand: IRequest<CreatedTrainerDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, CreatedTrainerDto>
        {
            private readonly ITrainerRepository _trainerRepository;
            private readonly IMapper _mapper;

            public CreateTrainerCommandHandler(ITrainerRepository trainerRepository, IMapper mapper)
            {
                _trainerRepository = trainerRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTrainerDto> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
            {
                Trainer mappedMember = _mapper.Map<Trainer>(request);
                Trainer createdMember = await _trainerRepository.AddAsync(mappedMember);
                CreatedTrainerDto createdMemberDto = _mapper.Map<CreatedTrainerDto>(createdMember);
                return createdMemberDto;
            }
        }
    }
}
