﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersConsoleApp
{

    public class StatusOrderService
    {
        private List<StatusOrder> statusOrders;

        public StatusOrderService()
        {
            statusOrders = new List<StatusOrder>();
        }

        public StatusOrderService Initialize(StatusOrderService statusOrderService)
        {
            statusOrderService.AddNewStatusOrders(1, "Nowe");
            statusOrderService.AddNewStatusOrders(2, "W realizacji");
            statusOrderService.AddNewStatusOrders(2, "Zrealizowane");

            return statusOrderService;
        }

        public void AddNewStatusOrders(int id, string name)
        {
            StatusOrder statusOrder = new StatusOrder(id, name);
            statusOrders.Add(statusOrder);
        }

        public List<StatusOrder> GetAllStatus()
        {
            return statusOrders;
        }
    }
}
