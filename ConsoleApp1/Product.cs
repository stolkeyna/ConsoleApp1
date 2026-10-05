using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

//zakres nazw w którym pracujemy, w którym nazwy są nie powtarzalne
namespace ConsoleApp1
{
    //internal jest opcjonalne
    internal class Product
    {
        private string _name;
        public string Name
        {
            //hermetyzacja
            get { return _name; }
            set
            {
                if(value == string.Empty)
                {
                    _name = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _name = value;
                }
            }
        }
        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    _price = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _price = value;
                }
            }
        }
        public int minimalAmmount;

        public string Category;
        public int Ammount { get; private set; }

        //właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WarehouseValue
        {
            get { return _price * Ammount; }
        }
        //Konstruktor - wymaga podanie wszystkich wartości przy tworzeniu objektu
        public Product(string name, double price, string category, int ammount, int minimalAmmount)
        {
            Name = name;
            Price = price;
            Category = category;
            Ammount = ammount;
            MinimalAmmount = 1;
        }
        //Ten konstruktor - wymaga tylko nazwy
        public Product(string name)
        {
            Name = name;
            Price = 0;
            Category = "no category";
            Ammount = 0;
        }
        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Name,-25}| Cena: {Price,10:F2}| Kategoria: {Category}| Ilość: {Ammount,5}");
        }
        public override string ToString()
        {
            return $"Nazwa: {Name,-25}| Cena: {Price,10:F2}| Kategoria: {Category}| Ilość: {Ammount,5}";
        }
        public static double ObliczWartoscMagazynu(Product[] products)
        {
            double sum = 0;
            foreach (Product product in products)
            {
                sum += product.WarehouseValue;
            }
            return sum;
        }
        public bool CzyMożnaZamówić()
        {
            return Ammount > minimalAmmount; //Jeżeli ilość jest większa minimalnego stanu, można zamówić
        }
        public void sprzedaj()
        {
            if (CzyMożnaZamówić())
            {
                //tak, zdejmij ze stanu 1 sztukę
                Ammount--;
                Console.WriteLine($"Szprzedano produkt: {Name}. Pozostało na stanie: {Ammount}");
            }
            else
            {
                //nie, nie można sprzedać
                Console.WriteLine($"Nie można sprzedać produkt {Name}. Brak produktu na stanie.");
            }
        }
    }
}
