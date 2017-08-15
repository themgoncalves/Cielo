using System.ComponentModel;

namespace Cielo.Enums
{
    public enum Status
    {
        [Description("Falha ao processar o pagamento")]
        NotFinished = 0,
        [Description("Meio de pagamento apto a ser capturado ou pago (Boleto)")]
        Authorized = 1,
        [Description("Pagamento confirmado e finalizado")]
        PaymentConfirmed = 2,
        [Description("Transação negada")]
        Denied = 3,
        [Description("Pagamento cancelado")]
        Voided = 10,
        [Description("Pagamento Cancelado/Estornado")]
        Refunded = 11,
        [Description("Esperando retorno da instituição financeira")]
        Pending = 12,
        [Description("Pagamento cancelado por falha no processamento")]
        Aborted = 13,
        [Description("Recorrência agendada")]
        Scheduled = 20
    }
}
