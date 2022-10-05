using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.Trainers.Commands.CreateTrainer;
using GymManagement.Application.Features.Trainers.Commands.DeleteTrainer;
using GymManagement.Application.Features.Trainers.Commands.UpdateTrainer;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Mappings
{
    public class TrainerProfiles: Profile
    {
        public TrainerProfiles()
        {
            //create trainer
            CreateMap<Trainer, CreatedTrainerDto>().ReverseMap();
            CreateMap<Trainer, CreateTrainerCommand>().ReverseMap();
            //read trainers
            CreateMap<IPaginate<Trainer>, TrainerListModel>().ReverseMap();
            CreateMap<Trainer, TrainerListDto>().ForMember(fm => fm.Members, opt => opt.MapFrom(mf => mf.Members)).ReverseMap();
            CreateMap<TrainerListDto, MemberListDto>().ReverseMap();
            //delete trainer
            CreateMap<Trainer, UpdatedTrainerDto>().ReverseMap();
            CreateMap<Trainer, UpdateTrainerCommand>().ReverseMap();
            //update trainer
            CreateMap<Trainer, DeleteTrainerCommand>().ReverseMap();
            CreateMap<Trainer, DeletedTrainerDto>().ReverseMap();
        }
    }
}
