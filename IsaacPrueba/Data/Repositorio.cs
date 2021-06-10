using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacPrueba.Data
{
    public class Repositorio
    {
        private readonly string _connectionString;
        public Repositorio(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
