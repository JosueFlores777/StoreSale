using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DBContext;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Implementation
{
    public class GenereciReposity<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SaleStoreContext dBContext;

        public GenereciReposity(SaleStoreContext saleStoreContext) {
            dBContext = saleStoreContext;
        }   

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try { 
            TEntity entity = await dBContext.Set<TEntity>().FirstOrDefaultAsync(filter);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetInformation(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
