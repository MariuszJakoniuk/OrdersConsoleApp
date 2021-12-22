using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersConsoleApp
{
 
    public class TypeOrderService
    {
        private List<TypeOrder> typeOrders;

        public TypeOrderService()
        {
            typeOrders = new List<TypeOrder>();
        }

        public TypeOrderService Initialize(TypeOrderService typeOrderService)
        {
            typeOrderService.AddNewOrdersType(1, "Klient");
            typeOrderService.AddNewOrdersType(2, "Dostawca");
            
            return typeOrderService;
        }

        public void AddNewOrdersType(int id, string name)
        {
            TypeOrder typeOrder = new TypeOrder(id, name);
            typeOrders.Add(typeOrder);
        }

        public List<TypeOrder> GetAllType()
        {
            return typeOrders;
        }
    }
}
