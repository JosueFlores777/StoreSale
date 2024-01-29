using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer.Interfaces
{
    public interface ISaleRepository: IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale entity);
        Task <List<SaleDetail>>Report(DateTime startDete, DateTime finalDate); 
    }
}
