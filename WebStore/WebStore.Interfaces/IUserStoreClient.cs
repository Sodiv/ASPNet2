using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces
{
    public interface IUserStoreClient : IUserStore<User>
    {
    }
}
