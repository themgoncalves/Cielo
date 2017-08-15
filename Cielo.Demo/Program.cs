using System;
using System.Configuration;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;

namespace Cielo.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateRequest();
            CreateRequestWithCardToken();
            CancelTransaction();
            CaptureTransaction();
            CapturePartialTransaction();
            CheckTransaction();
            SaveCard();

            Console.ReadLine();
        }

        private static void CreateRequest()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Creating a Transaction...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            Customer customer = new Customer("Marcos Gonçalves");

            CreditCard creditCard = new CreditCard("0000.0000.0000.0001",
                                            "João Nínguem",
                                            new CardExpiration(2017, 9), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            try
            {
                var response = cieloService.CreateTransaction(transaction);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! Transaction Status: {response.Status}, Tid: {response.Tid}, PaymentId: {response.PaymentId}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        
        private static void CreateRequestWithCardToken()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Creating a Transaction with Card Token...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            Customer customer = new Customer("John Doe");

            CreditCard creditCard = new CreditCard("6e1bf77a-b28b-4660-b14f-455e2a1c95e9", "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            try
            {
                var response = cieloService.CreateTransaction(transaction);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! Transaction Status: {response.Status}, Tid: {response.Tid}, PaymentId: {response.PaymentId}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }

        private static void CancelTransaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Canceling a Transaction...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            try
            {
                var response = cieloService.CancelTransaction(merchantOrderId: "123123");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! Transaction canceled. Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        
        private static void CaptureTransaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Capturing a Full Transaction...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            try
            {
                var response = cieloService.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! Transaction captured. Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        
        private static void CapturePartialTransaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Capturing a Partial Transaction...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);
            
            try
            {
                var response = cieloService.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"), 20.00m);
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! Transaction partially captured. Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }

        private static void CheckTransaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Checking a Transaction...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            try
            {
                var response = cieloService.CheckTransaction(merchantOrderId: "14421");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! ReasonCode: {response.ReasonCode}, ReasonMessage: {response.ReasonMessage}, Number of Payments made: {response.Payments.Count}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        
        private static void SaveCard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Saving a Card...");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            CreditCardRequest request = new CreditCardRequest("John Doe", "0000.0000.0000.0004", "John Doe", new CardExpiration(2020,8), CardBrand.MasterCard);
            
            try
            {
                var response = cieloService.SaveCard(request);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Done! CardToken: {response.CardToken}");
            }
            catch (ResponseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Id: {ex.ResponseError.Id}, Message: {ex.ResponseError.Message}, HttpStatusCode: {ex.ResponseError.HttpStatusCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ops! There was an error. Message: {ex.Message}, Source: {ex.Source}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
    }
}
