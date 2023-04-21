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
