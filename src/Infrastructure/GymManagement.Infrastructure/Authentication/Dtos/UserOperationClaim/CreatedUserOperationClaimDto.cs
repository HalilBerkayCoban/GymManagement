﻿namespace GymManagement.Infrastructure.Authentication.Dtos.UserOperationClaim
{
    public class CreatedUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
