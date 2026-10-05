using ConsoleApp1;
using System.Diagnostics.CodeAnalysis;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz", "Karta graficzna" };
//double[] ceny = { 899.00, 249.50, 379.00, 189.99, 599.00 };

//utwórz nowy obiekt processor według definicji klasy Product
Product processor = new Product("AMD Ryzen", 890.00, "Podzespoły", 5);
Product ram = new Product("Pamięć RAM", 250.00, "Podzespoły", 5);
Product ssd = new Product("Dysk ssd", 360.99, "Podzespoły", 5);
Product zasilacz = new Product("Zasilacz", 190.00, "Podzespoły", 5);


//tworzymy tablice produktów
Product[] products = {processor, ram, ssd, zasilacz};
double sum = 0;
int count = 0;
double LowestPrice = 0;
double HighestPrice = 0;
foreach (Product product in products)
{
    //Console.WriteLine($"Nazwa: {product.Name, -25}| Cena: {product.Price, 10:F2}| Kategoria: {product.Category}| Ilość: {product.Ammount, 5}");
    product.WypiszProdukt();
    sum += product.Price;
    count++;
    for(int i = 0; i<products.Length; i++)
    {
        LowestPrice = product.Price;
        if (product.Price < LowestPrice)
        {
            LowestPrice = product.Price;
        }
    }
    for (int i = 0; i < products.Length; i++)
    {
        if (HighestPrice < product.Price)
        {
            HighestPrice = product.Price;
        }
    }
    for (int i = 0; i <= product.Ammount; i++)
    {
        product.sprzedaj();
    }
}
Console.WriteLine($"Najtańszy: {LowestPrice}");
double AveragePrice = sum / count;
Console.WriteLine($"Cena średnia: {AveragePrice}");
Console.WriteLine($"Najdroższy: {HighestPrice}");
double WarehouseValue = Product.ObliczWartoscMagazynu(products);
Console.WriteLine($"Suma wartości magazynu dla wszystkich produktów: {WarehouseValue:f2} zł");

//// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
//double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}.");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów droższych od 200zł.");