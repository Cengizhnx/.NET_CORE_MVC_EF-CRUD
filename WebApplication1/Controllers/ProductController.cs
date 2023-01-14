using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DBContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDBContext productsDBContext;
        public ProductController(ProductDBContext productsDBContext)
        {
            this.productsDBContext = productsDBContext;
        }

        public IActionResult Index()
        {
            var products = productsDBContext.Product.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(Product addProductRequest)
        {
            var product = new Product()
            {
                //ProductId = Guid.NewGuid(),
                Name = addProductRequest.Name,
                ProductNumber = addProductRequest.ProductNumber,
                Color = addProductRequest.Color,
                StandardCost = addProductRequest.StandardCost,
                ListPrice = addProductRequest.ListPrice,
                SellStartDate = addProductRequest.SellStartDate,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = addProductRequest.ModifiedDate,
            };

            await productsDBContext.Product.AddAsync(product);
            await productsDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var product = await productsDBContext.Product.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product != null)
            {
                var viewModel = new Product()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    Color = product.Color,
                    StandardCost = product.StandardCost,
                    ListPrice = product.ListPrice,
                    SellStartDate = product.SellStartDate,
                    Rowguid = product.Rowguid,
                    ModifiedDate = product.ModifiedDate,
                };
                return await Task.Run(() => View("View",viewModel));

            }

            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public async Task<IActionResult> View(Product model)
        {
            var product = await productsDBContext.Product.FindAsync(model.ProductId);

            if (product != null)
            {
                product.Name = model.Name;
                product.ProductNumber = model.ProductNumber;
                product.Color = model.Color;
                product.StandardCost = model.StandardCost;
                product.ListPrice = model.ListPrice;
                product.SellStartDate = model.SellStartDate;
                product.ModifiedDate = model.ModifiedDate;

                await productsDBContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product model)
        {
            var product = await productsDBContext.Product.FindAsync(model.ProductId);

            if (product != null)
            {
                productsDBContext.Product.Remove(product);

                await productsDBContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }
    }
}
