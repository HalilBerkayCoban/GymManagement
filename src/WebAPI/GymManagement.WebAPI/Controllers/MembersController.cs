using GymManagement.Application.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var members = _memberRepository.GetAsync();
        //    return Ok(members);
        //}
    }
}
