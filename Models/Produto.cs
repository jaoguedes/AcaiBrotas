using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcaiBrotas.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public string Name { get; set;}
        [DisplayName("Tipo")]
        public Guid TipoId { get; set; }
        public Tipo? Tipo { get; set; }
        public string Descricao { get; set;}
        public int Preco { get; set;}

    }
}
