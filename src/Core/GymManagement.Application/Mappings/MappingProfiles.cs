﻿using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Features.Models;
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
           
            //trainer
            CreateMap<Trainer, CreatedTrainerDto>().ReverseMap();
            CreateMap<Trainer, CreateTrainerCommand>().ReverseMap();
            CreateMap<IPaginate<Trainer>, TrainerListModel>().ReverseMap();
            CreateMap<Trainer, TrainerListDto>().ForMember(fm => fm.Members, opt => opt.MapFrom(mf => mf.Members)).ReverseMap();
            CreateMap<TrainerListDto, MemberListDto>().ReverseMap();
        }
    }
}
