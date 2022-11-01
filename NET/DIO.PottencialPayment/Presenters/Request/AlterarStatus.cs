using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottencialPayment.Models;

namespace DIO.PottencialPayment.Presenters.Request
{
    public class AlterarStatus
    {
        public int VendaId {get; set;}
        public StatusVendaEnum Status {get; set;}
    }
}