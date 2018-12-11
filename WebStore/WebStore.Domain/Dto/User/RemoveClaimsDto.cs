using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace WebStore.Domain.Dto.User
{
    public class RemoveClaimsDto
    {
        public Entities.User User { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
