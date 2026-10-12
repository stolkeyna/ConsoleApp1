using ConsoleApp1;
using System.Diagnostics.CodeAnalysis;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz", "Karta graficzna" };
//double[] ceny = { 899.00, 249.50, 379.00, 189.99, 599.00 };

//utwórz nowy obiekt processor według definicji klasy Product
Product processor = new Product("AMD Ryzen", 890.00, "Podzespoły", 2, 1);
Product ram = new Product("Pamięć RAM", 250.00, "Podzespoły", 2, 1);
Product ssd = new Product("Dysk ssd", 360.99, "Podzespoły", 2, 1);
Product zasilacz = new Product("Zasilacz", 190.00, "Podzespoły", 2, 1);


//tworzymy tablice produktów
Product[] products = {processor, ram, ssd, zasilacz};
//pusta tablica na 10 produktów
Product[] products2 = new Product[10];
//jeśli chcemy listę:
//najpierws słowo List potem w nawiasach ostrych <> typ dannych który chcielibyśmy przecowywać
//potem nazwa zmiennej i przypisujemy kpnstruktorem nową pustą listę
List<Product> listaProduktow = new List<Product>();
//mając listę dodajemy do niej elementy metodą Add
listaProduktow.Add(processor);
listaProduktow.Add(ram);
listaProduktow.Add(ssd);
listaProduktow.Add(zasilacz);

double sum = 0;
int count = 0;
double LowestPrice = 0;
double HighestPrice = 0;
//tu możemy wymienić sobie tablicę na listę i odwrotnie i to zarówno będzie działać
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

//dla listy możemy użyć LINQ do sumowania całości
double sumaListy = listaProduktow.Sum(p => p.Price); // czytamy jako dla każdego produktu sumuj pole Price
//albo możemy odfiltrować LINQ produkty sroższe niż 200zł i zsumować tylko te droższe
List<Product> drogieProdukty = listaProduktow.Where(p => p.Price > 200).ToList();
//można połączyć te dwie metody
double sumaDroższychProduktow = listaProduktow.Where(p => p.Price > 200).Sum(p => p.Price);
double sredniaListy = listaProduktow.Average(p => p.Price);
double wartoscListy = Product.ObliczWartoscMagazynu(listaProduktow);

Product p = Product.ZnajdzPoNazwie(products, "AMD Ryzen");
Console.WriteLine($"Znaleziono produkt {p.Name} o cenie {p.Price:C}");

//// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
//double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}.");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów droższych od 200zł.");