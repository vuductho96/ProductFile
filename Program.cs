using System;
using System.Collections.Generic;
using System.IO;

class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public string OtherDescription { get; set; }

    public override string ToString()
    {
        return $"{ProductCode}, {ProductName}, {Manufacturer}, {Price}, {OtherDescription}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "products.txt";
        List<Product> products = new List<Product>();

        while (true)
        {
            Console.WriteLine("\n1. Add product");
            Console.WriteLine("2. Display products");
            Console.WriteLine("3. Search product");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("\nAdding product...");
                    Product product = new Product();

                    Console.Write("Product code: ");
                    product.ProductCode = Console.ReadLine();

                    Console.Write("Product name: ");
                    product.ProductName = Console.ReadLine();

                    Console.Write("Manufacturer: ");
                    product.Manufacturer = Console.ReadLine();

                    Console.Write("Price: ");
                    product.Price = double.Parse(Console.ReadLine());

                    Console.Write("Other description: ");
                    product.OtherDescription = Console.ReadLine();

                    products.Add(product);

                    // Save to file
                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine($"{product.ProductCode},{product.ProductName},{product.Manufacturer},{product.Price},{product.OtherDescription}");
                    }

                    Console.WriteLine("Product added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\nList of products:");
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            Product p = new Product()
                            {
                                ProductCode = parts[0],
                                ProductName = parts[1],
                                Manufacturer = parts[2],
                                Price = double.Parse(parts[3]),
                                OtherDescription = parts[4]
                            };
                            Console.WriteLine(p);
                        }
                    }
                    break;

                case 3:
                    Console.Write("\nEnter product code to search: ");
                    string searchCode = Console.ReadLine();
                    bool found = false;
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts[0] == searchCode)
                            {
                                found = true;
                                Product p = new Product()
                                {
                                    ProductCode = parts[0],
                                    ProductName = parts[1],
                                    Manufacturer = parts[2],
                                    Price = Convert.ToDouble(parts[3]),
                                    OtherDescription = parts[4]
                                };
                                Console.WriteLine("Product found:");
                                Console.WriteLine(p.ToString());
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Product with code '{0}' not found.", searchCode);
                    }
                    break;
            }
        }
    }
}
            

