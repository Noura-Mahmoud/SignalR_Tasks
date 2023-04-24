using Microsoft.AspNetCore.SignalR;
using productsHub.Models;
using System.Diagnostics;

namespace productsHub.Hubs
{
    public class ProductHub : Hub
    {
        private readonly MainDbContext mainDbContext;

        public ProductHub(MainDbContext mainDbContext)
        {
            Debug.WriteLine("hub");
            this.mainDbContext = mainDbContext;
        }

        public void NewProduct(Product prod)
        {
            Debug.WriteLine("in c# prod");
            //var product = new Product
            //{
            //    Name= prod.Name,
            //    Description= prod.Description,
            //    Image = prod.Image,
            //    Price = prod.Price,
            //    Quantity = prod.Quantity
            //};
            Debug.WriteLine("before add prod");
            mainDbContext.Products.Add(prod);
            //mainDbContext.Products.Add(product);
            mainDbContext.SaveChanges();
            Debug.WriteLine("after add prod");

            // notify
            Clients.All.SendAsync("NotifyNewProduct", prod);
            Debug.WriteLine("after notify prod");
        }

        public void WriteComment(string name, string text, int product_id)
        {
            Debug.WriteLine("in c#");
            var comment = new Comment
            {
                UserName = name,
                Text = text,
                ProductId = product_id
            };
            Debug.WriteLine("before add");
            mainDbContext.Comments.Add(comment);
            mainDbContext.SaveChanges();
            Debug.WriteLine("after add");

            // notify
            Clients.All.SendAsync("NotifyNewComment", name, text, product_id);
            Debug.WriteLine("after notify");
        }

        public void buy (int productId, int quantity)
        {
            var product = mainDbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return;
            }
            var prodQuantity = product.Quantity;
            product.Quantity -= 1;
            mainDbContext.SaveChanges();

            //notify
            Clients.All.SendAsync("NotifyNewQuantity", productId, prodQuantity-1);
        }
    }
}
