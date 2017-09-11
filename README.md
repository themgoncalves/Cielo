[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)
[![forthebadge](http://forthebadge.com/images/badges/made-with-c-sharp.svg)](http://forthebadge.com)

# Cielo E-Commerce [![Travis](https://travis-ci.org/oforia/Cielo.svg)](https://travis-ci.org/oforia/Cielo)

Integração com o Webservice 3.0 do [Cielo E-Commerce](http://developercielo.github.io/Webservice-3.0/).
Projeto de demonstração na solução.


### Suporte

Os seguintes recursos do Webservice são suportados pela aplicação:

* Transação Simples (Cartão de Crédito e Débito).

* Transação Completa.

* Transação com Autenticação.

* Transação com Card Token.

* ~~Transação com Análise de Fraude~~.

* ~~Transação Recorrente~~.

* ~~Transação com Boleto~~.

* Transação com Transferência Eletrônica.

* Consulta de transação.

* Tokenização de Cartão - _Salvar cartão_ .

* ~~Wallet/Carteiras~~.



## Introdução

Existem dois métodos para você utilizar este repositório.

#### Familiar com Git?

Basta executar os comandos abaixos para iniciar:
```
> git clone https://github.com/oforia/Cielo.git
> cd Cielo
```
E após finalizar, abrir a solução (_Cielo.sln_) com o Visual Studio

#### Não é Familiar com Git?

Não tem problema, basta [Clicar aqui](https://github.com/oforia/Cielo/releases) para baixar o repositório em arquivo .zip e depois extrair em seu local favorito.


## Configurações

#### Web.config ou App.config

Basta você adicionar as seguintes chaves e substituir com seus valores na seção appSettings de seu Web.config ou App.config.

Não possui credenciais para Sandbox? [Clique aqui](https://cadastrosandbox.cieloecommerce.cielo.com.br) para seu o seu.
```xml
  <appSettings>

    <!-- Cielo -->
    <!--
    *************************   DEV   *************************
    <add key="cielo.endpoint.default" value="https://apisandbox.cieloecommerce.cielo.com.br" />
    <add key="cielo.endpoint.query" value="https://apiquerysandbox.cieloecommerce.cielo.com.br" />
    <add key="cielo.customer.id" value="" />
    <add key="cielo.customer.key" value="" />
    <add key="cielo.return.url" value="/" />

    *************************   PROD   *************************
    <add key="cielo.endpoint.default" value="https://api.cieloecommerce.cielo.com.br" />
    <add key="cielo.endpoint.query" value="https://apiquery.cieloecommerce.cielo.com.br" />
    <add key="cielo.customer.id" value="" />
    <add key="cielo.customer.key" value="" />
    <add key="cielo.return.url" value="/" />
    -->
    
    <add key="cielo.endpoint.default" value="https://apisandbox.cieloecommerce.cielo.com.br" />
    <add key="cielo.endpoint.query" value="https://apiquerysandbox.cieloecommerce.cielo.com.br" />
    <add key="cielo.customer.id" value="" />
    <add key="cielo.customer.key" value="" />
    <add key="cielo.return.url" value="/" />
  </appSettings>

```


### Na aplicação

Utilize o código abaixo caso _queira personalizar_ os valores, se não a aplicação irá **procurar automaticamente pelas configurações** em seu Web.config ou App.config .

```csharp
using Cielo.Configuration;
//...
CustomConfiguration configuration = new CustomConfiguration()
{
    DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
    QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
    MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
    MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
    ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
};

CieloService cieloService = new CieloService(configuration);

```

## Documentação

Os exemplos a seguir se aplicam na grande maioria dos casos, mas se mesmo assim precisar de algo diferente, basta ler a [Documentação da Cielo](http://developercielo.github.io/Webservice-3.0/) e personalizar as _models_ para envio.

### Criando uma transação com cartão de crédito


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

var customer = new Customer("John Doe");

var creditCard = new CreditCard("0000.0000.0000.0001",
                                "John Doe",
                                new CardExpiration(2020, 9), "123", CardBrand.Visa);

var payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

var transaction = new TransactionRequest("128745", customer, payment);

var cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CreateTransaction(transaction);
    Console.WriteLine($"Feito! Status: {response.Status}, Tid: {response.Tid}, PaymentId: {response.PaymentId}"); //exemplo de retorno
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

### Criando uma transação com cartão de débito


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

var customer = new Customer("John Doe");

var debitCard = new DebitCard("0000.0000.0000.0001",
                              "John Doe",
                              new CardExpiration(2017, 9), "123", CardBrand.Visa);

var payment = new Payment(PaymentType.DebitCard, 380.2m, 1, "", debitCard: debitCard, returnUrl: configuration.ReturnUrl);

var transaction = new TransactionRequest("128745", customer, payment);

var cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CreateTransaction(transaction);
    Console.WriteLine($"Feito! Status: {response.Status}, Tid: {response.Tid}, PaymentId: {response.PaymentId}, AuthenticationUrl: {response.AuthenticationUrl}"); //exemplo de retorno
    //Você deve redirecionar o usuário para a URL fornecida no 'response.AuthenticationUrl'
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

### Criando uma transação com Card Token


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

var customer = new Customer("John Doe");

var creditCard = new CreditCard("6e1bf77a-b28b-4660-b14f-455e2a1c95e9", "123", CardBrand.Visa); // <-- basta informar o CardToken, SecurityCode e a Brand do cartão

var payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

var transaction = new TransactionRequest("128745", customer, payment);

var cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CreateTransaction(transaction);
    Console.WriteLine($"Feito! Status: {response.Status}, Tid: {response.Tid}, PaymentId: {response.PaymentId}"); //exemplo de retorno
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

### Criando uma transferência eletrônica


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

Customer customer = new Customer("John Doe");                        

Payment payment = new Payment(PaymentType.EletronicTransfer, 100.00m, EletronicTransferProvider.BancodoBrasil, "http://www.cielo.com.br/");

var transaction = new TransactionRequest("14421", customer, payment);

var cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CreateEletronicTransfer(transaction);
    Console.WriteLine($"Feito! Status: {response.Status}, PaymentId: {response.PaymentId}, Url: {response.Url}"); //exemplo de retorno
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

### Cancelando uma transação


#### Cancelar total


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    //você possui duas opções de consulta
    //1) através do MerchantOrderId;
    //2) Ou pelo PaymentId
    
    var response = cieloService.CancelTransaction(merchantOrderId: "123123");    
    //var response = cieloService.CancelTransaction(paymentId: Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"));
    
    Console.WriteLine($"Feito! Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

#### Cancelar parcialmente


```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    //você possui duas opções de consulta
    //1) através do MerchantOrderId;
    //2) Ou pelo PaymentId
    
    var response = cieloService.CancelTransaction(merchantOrderId: "123123", amount: 20.00m);    
    //var response = cieloService.CancelTransaction(paymentId: Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"), amount: 20.00m);
    
    Console.WriteLine($"Feito! Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

### Capturando uma transação


#### Captura Total

```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"));
    Console.WriteLine($"Feito! Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```


#### Captura Parcial

```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    var response = cieloService.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"), 20.00m); // <-- basta informar o valor que deseja capturar
    Console.WriteLine($"Feito! Status: {response.Status}, Return Code: {response.ReturnCode}, ReturnMessage: {response.ReturnMessage}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```


### Consultar Transação

```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    //você possui duas opções de consulta
    //1) através do MerchantOrderId;
    //2) Ou pelo PaymentId
    
    var response = cieloService.CheckTransaction(merchantOrderId: "14421");
    //var response = cieloService.CheckTransaction(paymentId: Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"));
    Console.WriteLine($"Feito! ReasonCode: {response.ReasonCode}, ReasonMessage: {response.ReasonMessage}, Number of Payments made: {response.Payments.Count}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```


### Salvando um Cartão

```csharp
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;
//...

CieloService cieloService = new CieloService(configuration);

try
{
    var request = new CreditCardRequest("John Doe", "0000.0000.0000.0004", "John Doe", new CardExpiration(2020,8), CardBrand.MasterCard);
    var response = cieloService.SaveCard(request);
    Console.WriteLine($"Feito! CardToken: {response.CardToken}");
}
catch (ResponseException ex)
{
    //Erro personalizado das Requisições
    //Error Id:       ex.ResponseError.Id
    //Message:        ex.ResponseError.Message
    //HttpStatusCode: ex.ResponseError.HttpStatusCode
}
catch (Exception ex)
{
    //erros genéricos
}
```

## Projeto de Demonstração

Ao abrir a solução (_Cielo.sln_) você encontrará um projeto chamado **Cielo.Demo**.
Para executá-lo é simples, basta seguir os seguintes passos:
1) Clicando o _botão direito_ do mouse em cima do projeto _Cielo.Demo_, clique em _Complilar_ ou _Recompilar_.
2) Após, basta você abrir o _Prompt de Comando_ do Windows.
3) Com o Prompt aberto, execute a seguinte instrução:
```
> cd C:\DIRETORIO_DO_MEU_PROJETO\Cielo.Demo\bin\Debug
> Cielo.Demo.exe
```
OBS: Você deverá trocar o _DIRETORIO_DO_MEU_PROJETO_ pelo endereço do local de seu projeto.

Após isso, você deverá ver a seguinte saída no prompt:

```
Choose an option to execute

Commands available:
all                 : Execute all available tests
cancel              : Cancel a transaction
capture             : Capture a transaction
capture-partial     : Capture partially a transaction
check               : Check a transaction
eletronic           : Create a new eletronic transfer
new                 : Create a new transaction
new-cardtoken       : Create a new transaction with a Card Token
savecard            : Salvar um Cartão de Crédito

```

E pronto! Para utilizar basta selecionar uma opção, por exemplo:

```
> Cielo.Demo.exe all
```
ou 

```
> Cielo.Demo.exe capture
```
ou

```
> Cielo.Demo.exe new
```