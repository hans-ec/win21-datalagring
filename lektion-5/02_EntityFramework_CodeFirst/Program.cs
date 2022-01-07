using _02_EntityFramework_CodeFirst.Models;
using _02_EntityFramework_CodeFirst.Services;

ICategoryService categoryService = new CategoryService();
ISubCategoryService subCategoryService = new SubCategoryService();
IProductService productService = new ProductService();

categoryService.Create(new Category { Name = "Ljud och Bild" });
subCategoryService.Create(new SubCategory { Name = "TV", CategoryId = 1 });
productService.Create(new Product { Name = "LG Smart TV 85\"", Description = "85\" smart tv från LG med bästa upplösningen", Price = 14599, SubCategoryId = 1 });


foreach (var product in productService.GetAll())
{
    Console.WriteLine($"{product.Id} : {product.Name} (Pris: {product.Price} SEK)");
    Console.WriteLine(product.Description);
    Console.WriteLine($@"Kategori: {product.SubCategory.Category.Name} / {product.SubCategory.Name}");
    Console.WriteLine("");
}
