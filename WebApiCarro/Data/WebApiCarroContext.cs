using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCarro.Models;

namespace WebApiCarro.Data
{
    public class WebApiCarroContext : DbContext
    {
        public WebApiCarroContext (DbContextOptions<WebApiCarroContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiCarro.Models.Carro> Carro { get; set; }
    }
}
