using FullProject.Aplication.Absreaction;
using FullProject.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Infrastucture.Data
{
    public class DbConnect : DbContext, IDbConnect
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }
       
        public DbSet<User> users { get ; set ; }

        async ValueTask<int> IDbConnect.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
