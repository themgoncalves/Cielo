using System.ComponentModel;

namespace Cielo.Enums
{
    public enum CardBrand
    {
        [Description("Visa")]
        Visa,
        [Description("Master")]
        MasterCard,
        [Description("Amex")]
        AmericanExpress,
        [Description("Elo")]
        Elo,
        [Description("Diners")]
        DinersClub,
        [Description("Discover")]
        Discover,
        [Description("JCB")]
        JCB,
        [Description("Aura")]
        Aura
    }
}
