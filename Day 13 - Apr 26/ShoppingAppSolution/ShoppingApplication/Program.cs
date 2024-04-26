using ShoppingModelLibrary;
using ShoppingBLLibrary.Services;
using ShoppingBLLibrary.BL;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IProductService productService = new ProductBL();
            ICustomerService customerService = new CustomerBL();
            ICartService cartService = new CartBL();

            while (true)
            {
                Console.WriteLine("Welcome to the Shopping System!");
                Console.WriteLine("1. Manage Products");
                Console.WriteLine("2. Manage Customers");
                Console.WriteLine("3. Manage Carts");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await ManageProducts(productService);
                            break;
                        case 2:
                            await ManageCustomers(customerService);
                            break;
                        case 3:
                            await ManageCarts(cartService);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static async Task ManageProducts(IProductService productService)
        {
            while (true)
            {
                Console.WriteLine("Product Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await AddProduct(productService);
                            break;
                        case 2:
                            await DeleteProduct(productService);
                            break;
                        case 3:
                            await ViewAllProducts(productService);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static async Task AddProduct(IProductService productService)
        {
            Console.WriteLine("Enter Product Details:");
            Console.Write("Id: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();
                Console.Write("Price: ");
                double price;
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    Console.Write("Quantity in Hand: ");
                    int quantityInHand;
                    if (int.TryParse(Console.ReadLine(), out quantityInHand))
                    {
                        Product product = new Product(id, price, name!, quantityInHand);

                        try
                        {
                            int productId =  productService.AddProduct(product);
                            Console.WriteLine($"Product with Id {productId} added successfully.");
                        }
                        catch (NoProductWithGivenIdException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task DeleteProduct(IProductService productService)
        {
            Console.Write("Enter Product Id to delete: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                try
                {
                    Product deletedProduct =  productService.DeleteProduct(id);
                    Console.WriteLine($"Product with Id {deletedProduct.Id} deleted successfully.");
                }
                catch (NoProductWithGivenIdException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task ViewAllProducts(IProductService productService)
        {
            List<Product> products =  productService.GetAllProducts();
            Console.WriteLine("List of Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        static async Task ManageCustomers(ICustomerService customerService)
        {
            while (true)
            {
                Console.WriteLine("Customer Management");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Delete Customer");
                Console.WriteLine("3. View All Customers");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await AddCustomer(customerService);
                            break;
                        case 2:
                            await DeleteCustomer(customerService);
                            break;
                        case 3:
                            await ViewAllCustomers(customerService);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static async Task AddCustomer(ICustomerService customerService)
        {
            Console.WriteLine("Enter Customer Details:");
            Console.Write("Id: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();
                Console.Write("Phone: ");
                string? phone = Console.ReadLine();
                Console.Write("Age: ");
                int age;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    Customer customer = new Customer
                    {
                        Id = id,
                        Name = name!,
                        Phone = phone!,
                        Age = age
                    };

                    try
                    {
                        int customerId =  customerService.AddCustomer(customer);
                        Console.WriteLine($"Customer with Id {customerId} added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task DeleteCustomer(ICustomerService customerService)
        {
            Console.Write("Enter Customer Id to delete: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                try
                {
                    Customer deletedCustomer =  customerService.DeleteCustomer(id);
                    Console.WriteLine($"Customer with Id {deletedCustomer.Id} deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task ViewAllCustomers(ICustomerService customerService)
        {
            List<Customer> customers =  customerService.GetAllCustomers();
            Console.WriteLine("List of Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        static async Task ManageCarts(ICartService cartService)
        {
            while (true)
            {
                Console.WriteLine("Cart Management");
                Console.WriteLine("1. Add Cart");
                Console.WriteLine("2. Delete Cart");
                Console.WriteLine("3. View All Carts");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await AddCart(cartService);
                            break;
                        case 2:
                            await DeleteCart(cartService);
                            break;
                        case 3:
                            await ViewAllCarts(cartService);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static async Task AddCart(ICartService cartService)
        {
            Console.WriteLine("Enter Cart Details:");
            Console.Write("Id: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                // Add code to read and set other cart details
                Cart cart = new Cart
                {
                    Id = id
                };

                try
                {
                    int cartId =  cartService.AddCart(cart);
                    Console.WriteLine($"Cart with Id {cartId} added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task DeleteCart(ICartService cartService)
        {
            Console.Write("Enter Cart Id to delete: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                try
                {
                    Cart deletedCart =  cartService.DeleteCart(id);
                    Console.WriteLine($"Cart with Id {deletedCart.Id} deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid id. Please enter a valid number.");
            }
        }

        static async Task ViewAllCarts(ICartService cartService)
        {
            List<Cart> carts =  cartService.GetAllCarts();
            Console.WriteLine("List of Carts:");
            foreach (var cart in carts)
            {
                Console.WriteLine(cart);
            }
        }
    }
}
