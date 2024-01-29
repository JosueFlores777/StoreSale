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
        public  async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                dBContext.Set <TEntity>().Add(entity);
                await dBContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                dBContext.Update(entity);
                await dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                dBContext.Remove(entity);
                await dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> GetInformation(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> queryEnity = filter == null ? dBContext.Set<TEntity>() : dBContext.Set<TEntity>().Where(filter);

                return queryEnity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
