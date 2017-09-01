using System;
using System.Configuration;
using System.Diagnostics;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests.Entites;
using Cielo.Requests.Entites.Common;
using Cielo.Responses.Exceptions;

namespace Cielo.Demo.Services
{
    public class SaveCard : ICieloDemo
    {
        private ICieloDemoInterface _app;

        public static CieloDemoInfo Info
        {
            get
            {
                var info = new CieloDemoInfo(
                    typeof(SaveCard),
                    "savecard",
                    "Salvar um Cartão de Crédito",
                    "");
                return info;
            }
        }

        #region ICieloDemo Members

        public void Execute(ICieloDemoInterface app)
        {
            this._app = app;
            this.GetArgs();
            this.ExecuteRequest();
        }

        #endregion

        private void GetArgs()
        {
            foreach (var arg in _app.Args)
            {

            }
        }

        private void ExecuteRequest()
        {
            var watch = Stopwatch.StartNew();
            ConsoleHelper.WriteHeader("Saving a Card");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            CreditCardRequest request = new CreditCardRequest("John Doe", "0000.0000.0000.0004", "John Doe", new CardExpiration(2020, 8), CardBrand.MasterCard);

            try
            {
                var response = cieloService.SaveCard(request);

                ConsoleHelper.WriteResult(response);
            }
            catch (ResponseException ex)
            {
                ConsoleHelper.WriteError(ex);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError(ex);
            }

            watch.Stop();
            ConsoleHelper.WriteFooter(watch.ElapsedMilliseconds);
        }
    }
}
