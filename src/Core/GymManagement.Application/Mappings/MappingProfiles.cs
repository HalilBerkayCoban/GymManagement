using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Features.Members.Models;
using GymManagement.Application.Features.Trainers.Commands.CreateTrainer;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            //member
            CreateMap<Member, CreatedMemberDto>().ReverseMap();
            CreateMap<Member, CreateMemberCommand>().ReverseMap();
            CreateMap<IPaginate<Member>, MemberListModel>().ReverseMap();
            CreateMap<Member, MemberListDto>().ReverseMap();
            //trainer
            CreateMap<Trainer, CreatedTrainerDto>().ReverseMap();
            CreateMap<Trainer, CreateTrainerCommand>().ReverseMap();
        }
    }
}
