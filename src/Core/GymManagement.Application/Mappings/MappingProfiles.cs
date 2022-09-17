using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Commands.CreateMember;
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
            CreateMap<Member, CreatedMemberDto>().ReverseMap();
            CreateMap<Member, CreateMemberCommand>().ReverseMap();

        }
    }
}
