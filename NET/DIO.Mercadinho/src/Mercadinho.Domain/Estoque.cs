using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Domain
{
    public class Estoque
    {
        public int Id { get; set; }

        public Produto Produto { get; set; }

        public int ProdutoId { get; set; }

        public Qualitativo InfoCompra { get; set; }
    }
}
