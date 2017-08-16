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
            Console.WriteLine("Reason Code".PadRight(25, ' ') + $": {response.ReasonCode}");
            Console.WriteLine("Reason Message".PadRight(25, ' ') + $": {response.ReasonMessage}");
            Console.WriteLine("");
            Console.WriteLine("");

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

        public static void WriteFooter(long runtime)
        { 
            string time = $"Runtime {runtime} ms";

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
            Console.WriteLine("HttpStatusCode".PadRight(20, ' ') + $": {ex.ResponseError.HttpStatusCode}");
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
