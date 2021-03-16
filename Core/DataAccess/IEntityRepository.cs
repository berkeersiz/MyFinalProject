using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic constraint--Generic kısıt
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı(Yani interface olan IEntity de eledik!
    //Artık T yerine isteyen istedigii koyamaz sadece IEntity'i implemente eden classlar yazılabilir.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        // List<T> GetAllByCategory(int categoryId);
        //Bu kod yerine üstteki ::::: List<T> GetAll(Expression<Func<T,bool>>filter=null);
        //T Get(Expression<Func<T, bool>> filter);  yazdik!!!


        //Bizim entity olarak bir generic yazma nedenimiz yarın biri başka bir şeye göre önüme getir derse Örneğin customera göre
        //bunları gettall add update update yapmak ist erse uğraşmicaz!Hadi yapalım

    }
}
