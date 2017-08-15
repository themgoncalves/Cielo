using System.ComponentModel;

namespace Cielo.Enums
{
    public enum CustomerIdentityType
    {
        [Description(null)]
        Default,
        [Description("RG")]
        RG,
        [Description("CPF")]
        CPF,
        [Description("CNPJ")]
        CNPJ
    }
}
