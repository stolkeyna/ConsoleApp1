using ConsoleApp1;
using System.Diagnostics.CodeAnalysis;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz", "Karta graficzna" };
//double[] ceny = { 899.00, 249.50, 379.00, 189.99, 599.00 };

//utwórz nowy obiekt processor według definicji klasy Product
Product processor = new Product();
//nadaj mu wartości pól
processor.Name = "AMD Ryzen";
processor.Price = 890.00;
processor.Categoty = "Podzespoły";
processor.Ammount = 10;

//można też tak
Product ram = new Product
{
    Name = "Pamięć RAM",
    Price = 250.00,
    Categoty = "Podzespoły",
    Ammount = 15
};

Product ssd = new Product
{
    Name = "Dysk ssd",
    Price = 360.99,
    Categoty = "Podzespoły",
    Ammount = 27
};
Product zasilacz = new Product
{
    Name = "Zasilacz",
    Price = 190.00,
    Categoty = "Podzespoły",
    Ammount = 13
};

//tworzymy tablice produktów
Product[] products = {processor, ram, ssd, zasilacz};

double sum = 0;
int count = 0;
double LowestPrice = 0;
foreach (Product product in products)
{
    Console.WriteLine($"Nazwa: {product.Name, -25}| Cena: {product.Price, 10:F2}| Kategoria: {product.Categoty}| Ilość: {product.Ammount, 5}");
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

}
double average = sum / count;
//Console.WriteLine($"Najtańszy: {}| cena średnia: {}| najdroższy: {}");
//for (int i = 0; i < nazwy.Length; i++)
//{
//    // Do sumy trafiają tylko produkty droższe niż 200 zł
//    if (ceny[i] > 200)
//    {
//        //1148.5
//        suma = suma + ceny[i];
//        licznik++;
//    }
//}

//// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
//double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}.");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów droższych od 200zł.");