using FluxoDiario.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Api.Extended
{
    public static class MigrationManager
    {
        public static WebApplication IniciarDatabase(this WebApplication webapp)
        {
            var scope = webapp.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            context.Database.Migrate();
            return webapp;
        }
    }
}
