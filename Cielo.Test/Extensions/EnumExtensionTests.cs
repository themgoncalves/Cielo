using Cielo.Extensions;
using Cielo.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Extensions
{
    [TestFixture]
    public class EnumExtensionTests
    {
        [Test]
        public void ToDescription_ShouldReturnEnumDescriptionAttribute()
        {
            PaymentType paymentType = PaymentType.CreditCard;

            paymentType.ToDescription().Should().Be("Cartão de Crédito");
        }

        [Test]
        public void ToDescription_ShouldReturnEnumToStringWhenThereIsNoDescriptionAttribute()
        {
            EletronicTransferProvider provider = EletronicTransferProvider.BancodoBrasil;

            provider.ToDescription().Should().Be(EletronicTransferProvider.BancodoBrasil.ToString());
        }

        [Test]
        public void ToEnum_ShouldConvertEnumStringValueToEnum()
        {
            PaymentType paymentType = PaymentType.EletronicTransfer;
            var convertedEnum = EnumExtension.ToEnum<PaymentType>("EletronicTransfer");

            paymentType.Should().Be(convertedEnum);
        }
        
        [Test]
        public void ToEnum_ShouldReturnPreSelectedDefaultEnumValueOnFailingConverting()
        {
            PaymentType paymentType = PaymentType.Boleto;
            var convertedEnum = EnumExtension.ToEnum<PaymentType>("NonExistentEnumValue", PaymentType.Boleto);

            paymentType.Should().Be(convertedEnum);
        }

        [Test]
        public void ToEnum_ShouldReturnPreSelectedDefaultEnumValueWhenValueIsEmpty()
        {
            PaymentType paymentType = PaymentType.Boleto;
            var convertedEnum = EnumExtension.ToEnum<PaymentType>("", PaymentType.Boleto);

            paymentType.Should().Be(convertedEnum);
        }
    }
}
