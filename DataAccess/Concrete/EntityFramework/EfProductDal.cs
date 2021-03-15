using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDispoable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var addedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//Bu ekleme işini yap.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var deletedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var updatedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();//Bu ekleme işini yap.
            }
        }
    }
}
