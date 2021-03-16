using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDispoable pattern implementation of c#
            using (TContext context = new TContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var addedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//Bu ekleme işini yap.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var deletedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//Using içine yazdıgınız nesneler using bitince garbage collector tarafından yokedilir.
            {
                var updatedEntity = context.Entry(entity);//referansi yakalaa şekli entityframworkte
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();//Bu ekleme işini yap.
            }
        }
    }
}
