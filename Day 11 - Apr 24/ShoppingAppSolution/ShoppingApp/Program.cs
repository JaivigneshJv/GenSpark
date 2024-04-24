using ShoppingDALLibrary;
using ShoppingBLLibrary;
using ShoppingModelLibrary;

namespace ShoppingApp
{
    class Program
    {
        static void Main()
        {
            // Initialize repositories
            var productRepository = new ProductRepository();
            var cartRepository = new CartRepository();
            var customerRepository = new CustomerRepository();

            // Initialize shopping service
            var shoppingService = new ShoppingService(productRepository, cartRepository);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Create Cart");
                Console.WriteLine("4. Calculate Total Price");
                Console.WriteLine("5. Apply Shipping Charge");
                Console.WriteLine("6. Apply Discount");
                Console.WriteLine("7. Check Max Quantity in Cart");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddProduct(productRepository);
                        break;
                    case 2:
                        AddCustomer(customerRepository);
                        break;
                    case 3:
                        CreateCart(cartRepository, customerRepository);
                        break;
                    case 4:
                        CalculateTotalPrice(cartRepository, shoppingService);
                        break;
                    case 5:
                        ApplyShippingCharge(cartRepository, shoppingService);
                        break;
                    case 6:
                        ApplyDiscount(cartRepository, shoppingService);
                        break;
                    case 7:
                        CheckMaxQuantityInCart(cartRepository, shoppingService);
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a number from the menu.");
                        break;
                }
            }
        }

        static void AddProduct(ProductRepository repository)
        {
            Console.Write("Enter Product Name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var product = new Product { Name = name!, Price = price };
            repository.Add(product);
            Console.WriteLine("Product added successfully.");
        }

        static void AddCustomer(CustomerRepository repository)
        {
            Console.Write("Enter Customer Name: ");
            string? phone = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            int? age = Console.Read();

            var customer = new Customer { Phone = phone!, Age = age ?? 0 };
            repository.Add(customer);
            Console.WriteLine("Customer added successfully.");
        }

        static void CreateCart(CartRepository cartRepository, CustomerRepository customerRepository)
        {
            Console.Write("Enter Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var customer = customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            var cart = new Cart { Customer = customer };
            cartRepository.Add(cart);
            Console.WriteLine("Cart created successfully.");
        }

        static void CalculateTotalPrice(CartRepository cartRepository, ShoppingService shoppingService)
        {
            Console.Write("Enter Cart Id: ");
            if (!int.TryParse(Console.ReadLine(), out int cartId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var cart = cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                Console.WriteLine("Cart not found.");
                return;
            }

            double totalPrice = shoppingService.CalculateTotalPrice(cart);
            Console.WriteLine($"Total Price: {totalPrice}");
        }

        static void ApplyShippingCharge(CartRepository cartRepository, ShoppingService shoppingService)
        {
            Console.Write("Enter Cart Id: ");
            if (!int.TryParse(Console.ReadLine(), out int cartId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var cart = cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                Console.WriteLine("Cart not found.");
                return;
            }

            shoppingService.ApplyShippingCharge(cart);
            Console.WriteLine($"Shipping Charge Applied. Total Price: {cart.ShippingCharge}");
        }

        static void ApplyDiscount(CartRepository cartRepository, ShoppingService shoppingService)
        {
            Console.Write("Enter Cart Id: ");
            if (!int.TryParse(Console.ReadLine(), out int cartId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var cart = cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                Console.WriteLine("Cart not found.");
                return;
            }

            shoppingService.ApplyDiscount(cart);
            Console.WriteLine($"Discount Applied. Total Discount: {cart.Discount}");
        }

        static void CheckMaxQuantityInCart(CartRepository cartRepository, ShoppingService shoppingService)
        {
            if (shoppingService is null)
            {
                throw new ArgumentNullException(nameof(shoppingService));
            }

            Console.Write("Enter Cart Id: ");
            if (!int.TryParse(Console.ReadLine(), out int cartId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            var cart = cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                Console.WriteLine("Cart not found.");
                return;
            }

            ShoppingService.CheckMaxQuantityInCart(cart);
            Console.WriteLine("Max Quantity Checked and Adjusted if necessary.");
        }
    }
}
