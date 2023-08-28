using BenchmarkDotNet.Running;
using Example2;
using Example2.NorthwindDB;


var summary = BenchmarkRunner.Run<BenchmarkLinqLamda>();

using NorthwindContext ctx = new NorthwindContextFactory().CreateDbContext(new string[0]);
List<Customers> anotherCustomerList = new List<Customers>();

// Eleman Operatörleri
var firstCustomer = (from customer in ctx.Customers select customer).First();
var lastCustomerInGermany = (from customer in ctx.Customers where customer.Country == "Germany" select customer).LastOrDefault();

// Sıralama Operatörleri
var orderedByContactName = from customer in ctx.Customers orderby customer.ContactName select customer;
var orderedByCountryDescending = from customer in ctx.Customers orderby customer.Country descending select customer;

// Set Operatörleri
var distinctCountries = (from customer in ctx.Customers select customer.Country).Distinct();
var combinedWithAnotherList = (from customer in ctx.Customers select customer).Union(anotherCustomerList); // anotherCustomerList önceden tanımlanmalıdır.

// Projeksiyon Operatörleri
var customerNames = from customer in ctx.Customers select customer.ContactName;

// Gruplama Operatörleri
var groupedByCountry = from customer in ctx.Customers group customer by customer.Country;

// Toplama Operatörleri
var customerList = (from customer in ctx.Customers select customer).ToList();

// Koşullu Operatörler
var fromUKOrGermany = from customer in ctx.Customers where customer.Country == "UK" || customer.Country == "Germany" select customer;

// Toplam Operatörleri
var numberOfCustomers = (from customer in ctx.Customers select customer).Count();
var averageLengthOfNames = (from customer in ctx.Customers select customer.ContactName.Length).Average();

// Kuantifikasyon Operatörleri
var areThereAnyFromTurkey = (from customer in ctx.Customers where customer.Country == "Turkey" select customer).Any();

// Bölme Operatörleri
var skipFirst10 = (from customer in ctx.Customers select customer).Skip(10).Take(5); // İlk 10'u atla, sonraki 5'ini al

// Nesne Nesnesi Operatörleri
var areTheySame = (from customer in ctx.Customers select customer).SequenceEqual(anotherCustomerList); // anotherCustomerList önceden tanımlanmalıdır.

// Üretim Operatörleri
var rangeOfNumbers = Enumerable.Range(1, 100); // 1'den 100'e kadar sayılar


