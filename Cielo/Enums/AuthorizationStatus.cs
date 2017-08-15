using Cielo.Extensions.Attributes;

namespace Cielo.Enums
{
    public enum AuthorizationStatus
    {
        [CieloStatus("Autorizado", "Operação realizada com sucesso")]
        Authorized = 4,
        [CieloStatus("Autorização Aleatória", "Operation Successful / Time Out")]
        RandonAuthorization1 = 4,
        [CieloStatus("Autorização Aleatória", "Operation Successful / Time Out")]
        RandonAuthorization2 = 99,
        [CieloStatus("Não Autorizado", "Não Autorizada")]
        NotAuthorized = 2,
        [CieloStatus("Não Autorizado", "Cartão Cancelado")]
        NotAuthorizedCardCanceled = 77,
        [CieloStatus("Não Autorizado", "Problemas com o Cartão de Crédito")]
        NotAuthorizedCardIssue = 70,
        [CieloStatus("Não Autorizado", "Cartão Bloqueado")]
        NotAuthorizedCardBloqued = 78,
        [CieloStatus("Não Autorizado", "Cartão Expirado")]
        NotAuthorizedCardExpired = 57,
        [CieloStatus("Não Autorizado", "Time Out")]
        NotAuthorizedTimeOut = 99
    }
}
