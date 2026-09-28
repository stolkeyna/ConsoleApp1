using System;
using System.Collections.Generic;
using System.Text;

//zakres nazw w którym pracujemy, w którym nazwy są nie powtarzalne
namespace ConsoleApp1
{
    //internal jest opcjonalne
    internal class Product
    {
        private string _name;
        public string Name
        {
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

        public string Categoty;
        public int Ammount;

        //właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WarehouseValue
        {
            get { return _price * Ammount; }
        }
    }
}
