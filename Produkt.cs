using System;
using System.Collections.Generic;

class Product
{
    public string Name;
    public int Quantity;
    public double UnitPrice;
    public Product(string name, int quantity, double unitPrice)
    {
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    public override string ToString()
    {
        return "Nazwa: " + Name + ", Ilość: " + Quantity + ", Cena: " + UnitPrice;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl produkty");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                Console.Write("Nazwa: ");
                string n = Console.ReadLine();
                Console.Write("Ilość: ");
                int q = int.Parse(Console.ReadLine());
                Console.Write("Cena jednostkowa: ");
                double u = double.Parse(Console.ReadLine());
                products.Add(new Product(n, q, u));
                Console.WriteLine("Dodano produkt.");
            }
            else if (choice == "2")
            {
                Console.Write("Podaj nazwę produktu do usunięcia: ");
                string name = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name.ToLower() == name.ToLower())
                    {
                        products.RemoveAt(i);
                        found = true;
                        break;
                    }
                }
                Console.WriteLine(found ? "Usunięto produkt." : "Nie znaleziono produktu.");
            }
            else if (choice == "3")
            {
                if (products.Count == 0)
                    Console.WriteLine("Brak produktów.");
                else
                {
                    foreach (Product prod in products)
                        Console.WriteLine(prod);
                }
            }
            else if (choice == "4")
            {
                Console.Write("Podaj nazwę produktu do aktualizacji: ");
                string name = Console.ReadLine();
                Product prod = null;
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name.ToLower() == name.ToLower())
                    {
                        prod = products[i];
                        break;
                    }
                }
                if (prod != null)
                {
                    Console.WriteLine("1. Aktualizuj ilość");
                    Console.WriteLine("2. Aktualizuj cenę");
                    Console.WriteLine("3. Aktualizuj oba");
                    Console.Write("Wybierz opcję: ");
                    string opt = Console.ReadLine();
                    if (opt == "1")
                    {
                        Console.Write("Nowa ilość: ");
                        prod.Quantity = int.Parse(Console.ReadLine());
                    }
                    else if (opt == "2")
                    {
                        Console.Write("Nowa cena jednostkowa: ");
                        prod.UnitPrice = double.Parse(Console.ReadLine());
                    }
                    else if (opt == "3")
                    {
                        Console.Write("Nowa ilość: ");
                        prod.Quantity = int.Parse(Console.ReadLine());
                        Console.Write("Nowa cena jednostkowa: ");
                        prod.UnitPrice = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa opcja.");
                    }
                }
                else
                {
                    Console.WriteLine("Produkt nie znaleziony.");
                }
            }
            else if (choice == "5")
            {
                double total = 0;
                for (int i = 0; i < products.Count; i++)
                {
                    total += products[i].Quantity * products[i].UnitPrice;
                }
                Console.WriteLine("Wartość magazynu: " + total);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Koniec programu.");
                running = false;
            }
            else
            {
                Console.WriteLine("Nieprawidłowa opcja.");
            }
            Console.WriteLine();
        }
    }
}
