using System;
using System.Collections.Generic;
using System.Text;
namespace POS
{
    public class Inventory
    {
        List<Product> products = new List<Product>();
        List<Cart> cartItems = new List<Cart>();
        public void addItem(Product p)
        {
            products.Add(p);
        }
        public void addCartItem(Cart c)
        {
            cartItems.Add(c);
        }
        public string Items(string a)
        {
            foreach (Product p in products)
            {
                if (p.Name.Contains(a))
                {
                    return "";
                }
            }
            return a;
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"ID",2}|{"Item:",25}|{"Price:",7}|{"Category:",15}|{"Description:",30}|");
            Console.WriteLine("====================================================================================");
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
        }
        public void BuildCart()
        {
            double cartTotal = 0;
            double totalTax = 0;
            do
            {
                Console.Write("\nPlease select item by ID: ");
                int customerSelection = int.Parse(Console.ReadLine());
                Console.WriteLine("\nHow many of this item would you like?");
                int selectionQuantity = int.Parse(Console.ReadLine());

                foreach (Product p in products)
                {
                    if (p.Id == customerSelection)
                    {
                        addCartItem(new Cart(p.Name, p.Price, selectionQuantity));
                        cartTotal = (cartTotal + (p.Price * selectionQuantity));
                        totalTax = cartTotal * .06;
                        cartTotal += totalTax;
                    }
                }
                
            }
            while (ContinueProgram());
            Console.Clear();

            Console.WriteLine("Receipt: ");
            foreach (Cart c in cartItems)
            {
                Console.WriteLine(c);
            }
            Console.Write($"Sales Tax: {totalTax.ToString("C2"),20}");
            Console.WriteLine($"\nCart Total: {cartTotal.ToString("C2"),20}");

            Console.WriteLine($"Change: {GetChange(cartTotal,GetMoney()).ToString("C2"),20}");

        }
        public double GetMoney()
        {
            double money;
            Console.Write("Please insert cash amount: ");
            money = double.Parse(Console.ReadLine());
            return money;
        }
        public double GetChange(double cartTotal, double money)
        {
            money = cartTotal - money;
            return money;
        }
        public void ClearCart()
        {
            cartItems.Clear();
        }

        public bool ContinueProgram()
        {
            char c;
            do
            {
                Console.WriteLine("Would you like to continue? y/n");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    return false;
                }
            } while (c != 'y' && c != 'Y');
            return true;
        }


    }
}