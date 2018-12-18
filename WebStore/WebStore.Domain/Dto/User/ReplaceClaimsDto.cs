using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Domain.Dto.User
{
    public class ReplaceClaimsDto
    {
        public Entities.User User { get; set; }

        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }
}
