using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.DBContext;
using DataAccessLayer.Interfaces;
using Entity;

namespace DataAccessLayer.Implementation
{
    public class SaleRepository : GenereciReposity<Sale>, ISaleRepository
    {

        public readonly SaleStoreContext dbcontextSale;

        public SaleRepository(SaleStoreContext dbContext): base (dbContext) {
            dbcontextSale = dbContext;
        }

        public async Task<Sale> Register(Sale entity)
        {
           Sale saleGenerete = new Sale();
            using (var transation = dbcontextSale.Database.BeginTransaction()) {
                try
                {
                    foreach (SaleDetail Sd in entity.SaleDetails)
                    {
                        Product Findproduct = dbcontextSale.Products.Where(p => p.IdProduct == Sd.IdProduct).First();

                        Findproduct.Stock = Findproduct.Stock - Sd.Quantity;
                        dbcontextSale.Products.Update(Findproduct);

                    }

                    await dbcontextSale.SaveChangesAsync();

                    CorrelativeNumber correlative=  dbcontextSale.CorrelativeNumbers.Where(n => n.Management == "Sale").First();

                    correlative.LastNumber = correlative.LastNumber + 1;
                    correlative.UpdateDate = DateTime.Now;

                    dbcontextSale.CorrelativeNumbers.Update(correlative);

                    await dbcontextSale.SaveChangesAsync();

                    string cero = string.Concat(Enumerable.Repeat("0",correlative.DigitCount.Value));
                    string numberSale = cero +correlative.LastNumber.ToString();

                    numberSale = numberSale.Substring(numberSale.Length - correlative.DigitCount.Value,correlative.DigitCount.Value);

                    entity.SaleNumber = numberSale;

                    await dbcontextSale.Sales.AddAsync(entity);
                    await dbcontextSale.SaveChangesAsync();

                    saleGenerete = entity;

                    transation.Commit();
                
                }
                catch (Exception ex)
                {
                    transation.Rollback();
                    throw ex;
                }
            }

            return saleGenerete;
        }

        public async Task<List<SaleDetail>> Report(DateTime startDete, DateTime finalDate)
        {
            List<SaleDetail> resumenList = await dbcontextSale.SaleDetails.Include( v => v.IdSaleNavigation).ThenInclude(u => u.IdUserNavigation).Include(v => v.IdSaleNavigation)
                .ThenInclude(t => t.IdSalesDocumentTypeNavigation).Where(dv => dv.IdSaleNavigation.RegistrationDate.Value.Date >= startDete.Date && 
                dv.IdSaleNavigation.RegistrationDate.Value.Date <= finalDate.Date).ToListAsync();

            return resumenList;
        }
    }
}
