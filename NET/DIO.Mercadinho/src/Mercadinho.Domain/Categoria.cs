using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Domain
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; } = default;
    }
}
