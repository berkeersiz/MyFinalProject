using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
        //Public yaptığın zaman bu classa diğer katmanlarda ulaşabilsin demektir!
        //Çünkü dataaccess ürünü veriye eriştircek business bunu kontrol edicek!
        //Bir classın defaultu internaldır. Yani bu classa sadece entities ulaşabilir demektir!
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
