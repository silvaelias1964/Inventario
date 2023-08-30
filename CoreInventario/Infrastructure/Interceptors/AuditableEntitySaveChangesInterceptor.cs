using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreInventario.Domain.Common;
using System.Threading;

namespace CoreInventario.Infrastructure.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuditableEntitySaveChangesInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData evenData, InterceptionResult<int> result)
        {
            UpdateEntities(evenData.Context);
            return base.SavingChanges(evenData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData evenData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(evenData.Context);
            return base.SavingChangesAsync(evenData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            // Sesion
            var user = _httpContextAccessor.HttpContext != null ? _httpContextAccessor.HttpContext.User : null;
            string nombreUsuario = "system";
            if (user.Identity.IsAuthenticated)
            {
                nombreUsuario = user.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreadoPor = nombreUsuario; // "system";
                    entry.Entity.FechaCreacion = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ActualizadoPor = nombreUsuario; //"system";
                    entry.Entity.FechaActualizacion = DateTime.Now;
                }

            }
        }
    }
}
