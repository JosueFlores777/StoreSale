using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Implementation;
/*using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interfaces;
*/
namespace InversionOfControl
{
    public static class Dependencies
    {
        public static void InjectDependency(this IServiceCollection service, IConfiguration configuration) {

            service.AddDbContext<SaleStoreContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("StringConnection"));

            });
            
            service.AddTransient(typeof(IGenericRepository<>),typeof(GenereciReposity<>));

            service.AddScoped<ISaleRepository, SaleRepository>();
        }

    }
}
