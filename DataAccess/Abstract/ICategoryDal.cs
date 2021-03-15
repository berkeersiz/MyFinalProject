using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //product olan şeyleri kategori içinde yazdık bunu entity repositorye koyucaz ve o bi generic olucak
        //istedigimiz zaman ordan  yazıcaz..


       
        
    }
}
