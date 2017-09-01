using System;
using Cielo.Responses;
using Cielo.Responses.Exceptions;

namespace Cielo.Demo
{
    public static class ConsoleHelper
    {
        public static void WriteHeader(string text)
        {
            short numberOfSpace = 80;
            int textSpace = (numberOfSpace / 2) - (text.Length /2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("┌".PadRight(numberOfSpace, '─') + "┐");
            Console.WriteLine("");
            Console.WriteLine("".PadLeft(textSpace, ' ') + text);
            Console.WriteLine("");
            Console.WriteLine("└".PadRight(numberOfSpace, '─') + "┘");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteResult(EletronicTransferResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("");
            Console.WriteLine("Done!");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Status".PadRight(25, ' ') + $": {response.Status}");
            Console.WriteLine("Url".PadRight(25, ' ') + $": {response.Url}");
            Console.WriteLine("PaymentId".PadRight(25, ' ') + $": {response.PaymentId}");
            Console.WriteLine("MerchantOrderId".PadRight(25, ' ') + $": {response.MerchantOrderId}");
            Console.WriteLine("Type".PadRight(25, ' ') + $": {response.PaymentType}");
            Console.WriteLine("Amount".PadRight(25, ' ') + $": {response.Amount}");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteResult(TransactionResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("");
            Console.WriteLine("Done!");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Status".PadRight(25, ' ') + $": {response.Status}");
            Console.WriteLine("Return Code".PadRight(25, ' ') + $": {response.ReturnCode}");
            Console.WriteLine("Return Message".PadRight(25, ' ') + $": {response.ReturnMessage}");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void WriteResult(CheckTransactionResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("");
            Console.WriteLine("Done!");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");

            if (response?.Payments.Count > 0)
            {
                Console.WriteLine("ReasonCode".PadRight(25, ' ') + $": {response?.ReasonCode}");
                Console.WriteLine("ReasonMessage".PadRight(25, ' ') + $": {response?.ReasonMessage}");
                Console.WriteLine("Number of Payments".PadRight(25, ' ') + $": {response?.Payments.Count}");
                Console.WriteLine("PaymentId".PadRight(25, ' ') + $": {response?.Payments[0].PaymentId}");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("MerchantOrderId".PadRight(25, ' ') + $": {response?.MerchantOrderId}");
                Console.WriteLine("Installments".PadRight(25, ' ') + $": {response?.Payment?.Installments}");
                Console.WriteLine("ServiceTaxAmount".PadRight(25, ' ') + $": {response?.Payment?.ServiceTaxAmount}");
                Console.WriteLine("Capture".PadRight(25, ' ') + $": {response?.Payment?.Capture}");
                Console.WriteLine("Authenticate".PadRight(25, ' ') + $": {response?.Payment?.Authenticate}");
                Console.WriteLine("ProofOfSale".PadRight(25, ' ') + $": {response?.Payment?.ProofOfSale}");
                Console.WriteLine("Tid".PadRight(25, ' ') + $": {response?.Payment?.Tid}");
                Console.WriteLine("AuthorizationCode".PadRight(25, ' ') + $": {response?.Payment?.AuthorizationCode}");
                Console.WriteLine("PaymentId".PadRight(25, ' ') + $": {response?.Payment?.PaymentId}");
                Console.WriteLine("Status".PadRight(25, ' ') + $": {response?.Payment?.Status}");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteResult(NewTransactionResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");

            Console.WriteLine("Done!");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Status".PadRight(25, ' ') + $": {response.Status}");
            Console.WriteLine("Tid".PadRight(25, ' ') + $": {response.Tid}");
            Console.WriteLine("PaymentId".PadRight(25, ' ') + $": {response.PaymentId}");
            Console.WriteLine("AuthorizationCode".PadRight(25, ' ') + $": {response.AuthorizationCode}");
            Console.WriteLine("Return Code".PadRight(25, ' ') + $": {response.ReturnCode}");
            Console.WriteLine("Return Message".PadRight(25, ' ') + $": {response.ReturnMessage}");
            Console.WriteLine("ProofOfSale".PadRight(25, ' ') + $": {response.ProofOfSale}");
            Console.WriteLine("MerchantOrderId".PadRight(25, ' ') + $": {response.MerchantOrderId}");
            Console.WriteLine("AuthenticationUrl".PadRight(25, ' ') + $": {response.AuthenticationUrl}");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void WriteResult(CardResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("");
            Console.WriteLine("Done!");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("CardToken".PadRight(25, ' ') + $": {response.CardToken}");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteFooter(long elapsedTime)
        { 
            string time = $"Elapsed {elapsedTime} ms";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine(" ".PadRight((80 - time.Length), ' ') + time);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteError(ResponseException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("");
            Console.WriteLine("Ops! There was an error.");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("");
            Console.WriteLine("HttpStatusCode".PadRight(20, ' ') + $": {ex.ResponseError.HttpStatusCode.ToString()}");
            Console.WriteLine("Id".PadRight(20, ' ') + $": {ex.ResponseError.Id}");
            Console.WriteLine("Message".PadRight(20, ' ') + $": {ex.ResponseError.Message}");
        }
        
        public static void WriteError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("");
            Console.WriteLine("Ops! There was an error.");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("");
            Console.WriteLine("Source".PadRight(20, ' ') + $": {ex.Source}");
            Console.WriteLine("Message".PadRight(20, ' ') + $": {ex.Message}");
        }
    }
}
