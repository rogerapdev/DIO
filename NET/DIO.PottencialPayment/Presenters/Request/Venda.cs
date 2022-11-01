using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottencialPayment.Models;

namespace DIO.PottencialPayment.Presenters.Request
{
    public class Venda
    {
        public Vendedor Vendedor {get; set;}
        public DateTime Data {get; set;}
        public List<Item> Items {get; set;}
    }
}