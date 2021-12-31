using _02_SqlStorage.Interfaces;
using _02_SqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Handlers
{
    public interface IOrderHandler : ISqlCommands
    {

    }

    public class OrderHandler : IOrderHandler
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-2\02_SqlStorage\Data\sql_database.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(object obj)
        {
            var cart = (Cart)obj;
            var order = new Order();

            order.TotalPrice = CalculateTotalPrice(cart.Items);
            order.VAT = CalculateVAT(order.TotalPrice);
            order.CustomerId = cart.CustomerId;
            order.OrderDate = DateTime.Now;
            order.DueDate = order.OrderDate.AddDays(30);

            order.Id = CreateOrder(order);
            CreateOrderRows(order.Id, cart.Items);
        }

        public object Get(int id)
        {
            var order = new Order();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Orders WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        order.Id = (int)result.GetValue(0);
                        order.CustomerId = (int)result.GetValue(1);
                        order.OrderDate = (DateTime)result.GetValue(2);
                        order.DueDate = (DateTime)result.GetValue(3);
                        order.VAT = (decimal)result.GetValue(4);
                        order.TotalPrice = (decimal)result.GetValue(5);
                    }
                }
            }

            return order;
        }

        public IEnumerable<object> GetAll()
        {
            var orders = new List<Order>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Orders", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = (int)result.GetValue(0),
                            CustomerId = (int)result.GetValue(1),
                            OrderDate = (DateTime)result.GetValue(2),
                            DueDate = (DateTime)result.GetValue(3),
                            VAT = (decimal)result.GetValue(4),
                            TotalPrice = (decimal)result.GetValue(5)
                        });
                    }
                }
            }

            return orders;
        }


        private decimal CalculateTotalPrice(List<CartItem> items)
        {
            decimal totalPrice = 0;

            foreach (var item in items)
                totalPrice += (item.Price * item.Quantity);

            return totalPrice;
        }

        private decimal CalculateVAT(decimal total)
        {
            return total * 0.2m;
        }

        private int CreateOrder(Order order)
        {
            var orderId = 0;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("IF EXISTS (SELECT Id FROM Customers WHERE Id = @CustomerId) INSERT INTO Orders (CustomerId, OrderDate, DueDate, VAT, TotalPrice) OUTPUT INSERTED.Id VALUES (@CustomerId, @OrderDate, @DueDate, @VAT, @TotalPrice)", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@DueDate", order.DueDate);
                    cmd.Parameters.AddWithValue("@VAT", order.VAT);
                    cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                    orderId = (int)cmd.ExecuteScalar();
                }
            }

            return orderId;
        }

        private void CreateOrderRows(int orderId, List<CartItem> items)
        {
            foreach(var item in items)
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("IF EXISTS (SELECT Id FROM Orders WHERE Id = @OrderId) IF NOT EXISTS (SELECT 1 FROM OrderRows WHERE OrderId = @OrderId AND ProductId = @ProductId) INSERT INTO OrderRows (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)", conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@Price", item.Price);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
