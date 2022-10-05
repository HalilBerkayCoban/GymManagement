using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Requests;
using GymManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Application.Features.Trainers.Queries.GetAllTrainers
{
    public class GetAllTrainersQuery: IRequest<TrainerListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetAllTrainersQueryHandler : IRequestHandler<GetAllTrainersQuery, TrainerListModel>
        {
            private readonly ITrainerRepository _trainerRepository;
            private readonly IMapper _mapper;

            public GetAllTrainersQueryHandler(ITrainerRepository trainerRepository, IMapper mapper)
            {
                _trainerRepository = trainerRepository;
                _mapper = mapper;
            }

            public async Task<TrainerListModel> Handle(GetAllTrainersQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Trainer> trainers = await _trainerRepository.GetListAsync(include: m => m.Include(i => i.Members),index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                TrainerListModel trainerListModel = _mapper.Map<TrainerListModel>(trainers);

                return trainerListModel;
            }
        }
    }
}
