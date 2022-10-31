using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Domain
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public ICollection<Categoria> Categorias { get; set; }

        public Estoque Estoque { get; set; } = default;
    }
}
