using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Commands.CreateMember;
using GymManagement.Application.Features.Members.Commands.DeleteMember;
using GymManagement.Application.Features.Members.Commands.UpdateMember;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Mappings
{
    public class MemberProfiles: Profile
    {
        public MemberProfiles()
        {
            //create member
            CreateMap<Member, CreatedMemberDto>().ReverseMap();
            CreateMap<Member, CreateMemberCommand>().ReverseMap();
            //read members
            CreateMap<IPaginate<Member>, MemberListModel>().ReverseMap();
            CreateMap<Member, MemberListDto>().ForMember(fm => fm.TrainerName, opt => opt.MapFrom(mf => mf.Trainer.FirstName + " " + mf.Trainer.LastName)).ReverseMap();
            //update member
            CreateMap<Member, UpdatedMemberDto>().ForMember(fm => fm.TrainerName, opt => opt.MapFrom(mf => mf.Trainer.FirstName + " " + mf.Trainer.LastName)).ReverseMap();
            CreateMap<Member, UpdateMemberCommand>().ReverseMap();
            //delete member
            CreateMap<Member, DeleteMemberCommand>().ReverseMap();
            CreateMap<Member, DeletedMemberDto>().ReverseMap();
        }
    }
}
