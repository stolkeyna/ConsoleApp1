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

        public string Category;
        public int Ammount { get; private set; }

        //właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WarehouseValue
        {
            get { return _price * Ammount; }
        }
        //Konstruktor - wymaga podanie wszystkich wartości przy tworzeniu objektu
        public Product(string name, double price, string category, int ammount)
        {
            Name = name;
            Price = price;
            Category = category;
            Ammount = ammount;
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
    }
}
