using FullProject.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullProject.Aplication.Absreaction
{
    public interface IDbConnect
    { 
        public DbSet<User> users { get; set; }


        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
