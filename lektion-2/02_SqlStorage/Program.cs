using _02_SqlStorage.Handlers;
using _02_SqlStorage.Models;

ICustomerHandler customerHandler = new CustomerHandler();
IProductHandler productHandler = new ProductHandler();
IOrderHandler orderHandler = new OrderHandler();

customerHandler.Create(new Customer { FirstName = "Tommy", LastName = "Mattin-Lassei", Email = "tommy@domain.com", Password = "BytMig123!" });
productHandler.Create(new Product { Name = "Product 2", Description = "This is product 2", StockPrice = 200 });

var cart = new Cart();
cart.CustomerId = 2;
cart.Items.Add(new CartItem { ProductId = 1, Quantity = 1, Price = 100 });
cart.Items.Add(new CartItem { ProductId = 2, Quantity = 2, Price = 200 });

orderHandler.Create(cart);