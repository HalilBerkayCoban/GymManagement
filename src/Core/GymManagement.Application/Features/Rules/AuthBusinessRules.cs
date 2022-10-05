using GymManagement.Application.Exceptions;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Authentication.Hashing;
using GymManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email already exists!");
        }

        public async Task MailMustExistWhenLoggingIn(string email)
        {
            if (email == null) throw new BusinessException("This email does not exist.");
        }

        public async Task VerifyUserPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Password is not correct.");
        }
    }
}
