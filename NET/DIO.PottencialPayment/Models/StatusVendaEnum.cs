using System.ComponentModel;

namespace PottencialPayment.Models
{
    public enum StatusVendaEnum
    {
        [Description("Pagamento aprovado")]
        PagamentoAprovado,
        [Description("Enviado para transportadora")]
        EnviadoTransportadora,
        [Description("Entregue")]
        Entregue,
        [Description("Cancelada")]
        Cancelada
    }
}
