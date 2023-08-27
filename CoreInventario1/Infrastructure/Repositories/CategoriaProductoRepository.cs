using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{
    public class CategoriaProductoRepository : RepositoryBase<CategoriaProducto>, ICategoriaProductoRepository
    {
        public CategoriaProductoRepository(ApplicationDbContext context)
            :base(context)
        {                
        }
    }
}
