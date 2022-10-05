using GymManagement.Application.Exceptions;
using GymManagement.Domain.Entities;
using System.Net.Mail;

namespace GymManagement.Application.Features.Rules
{
    public class CommonBusinessRules
    {
        public async Task GivenEmailShoulBeValid(Member member)
        {
            try
            {
                MailAddress email = new(member.Email);
            }
            catch
            {
                throw new BusinessException("Given Email is not valid");
            }
        }
        //todo phone number validation
        //todo dateofbirth validation
    }
}
