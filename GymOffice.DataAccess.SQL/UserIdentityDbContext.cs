using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.DataAccess.SQL
{
    public class UserIdentityDbContext : IdentityDbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
            : base(options)
        {

        }
    }
}
