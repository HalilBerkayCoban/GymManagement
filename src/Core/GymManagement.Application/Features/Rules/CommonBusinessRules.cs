using GymManagement.Application.Exceptions;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
