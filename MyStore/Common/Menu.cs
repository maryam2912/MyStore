using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Store.Model;
using Store.Services.Interfaces;
using Store.Enumeration;
using Store.Services;

namespace Store.Common
{
    public static class Menu
    {
        private static IProductService productService;
        private static ICategoryService categoryService;
        public static void MainMenu()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. Edit a product");
                Console.WriteLine("3. Delete a product");
                Console.WriteLine("4. Get a product by ID");
                Console.WriteLine("5. Get all products");
                Console.WriteLine("6. Add a category");
                Console.WriteLine("7. Edit a category");
                Console.WriteLine("8. Delete a category");
                Console.WriteLine("9. Get a category by ID");
                Console.WriteLine("10.Get all categories");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                MenuOption menuOption = (MenuOption)Enum.Parse(typeof(MenuOption), Console.ReadLine());
                switch (menuOption)
                {
                    case MenuOption.AddProduct:
                        Console.Clear();
                        AddProduct();
                        break;
                    case MenuOption.EditProduct:
                        Console.Clear();
                        EditProduct();
                        break;
                    case MenuOption.DeleteProduct:
                        Console.Clear();
                        DeleteProduct();
                        break;
                    case MenuOption.GetProductById:
                        Console.Clear();
                        GetProductById();
                        break;
                    case MenuOption.GetAllProducts:
                        Console.Clear();
                        GetAllProducts();
                        break;
                    case MenuOption.AddCategory:
                        Console.Clear();
                        AddCategory();
                        break;
                    case MenuOption.EditCategory:
                        Console.Clear();
                        EditCategory();
                        break;
                    case MenuOption.DeleteCategory:
                        Console.Clear();
                        DeleteCategory();
                        break;
                    case MenuOption.GetCategoryById:
                        Console.Clear();
                        GetCategoryById();
                        break;
                    case MenuOption.GetAllCategories:
                        Console.Clear();
                        GetAllCategories();
                        break;
                    case MenuOption.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        #region Product Methos

        static void AddProduct()
        {
            Product product = new Product();

            Console.Write("Enter product ID: ");
            product.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter product name: ");
            product.Name = Console.ReadLine();

            Console.Write("Enter product Price: ");
            product.Price = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter product description: ");
            product.Description = Console.ReadLine();

            Console.Write("Enter CategoryId: ");
            product.CategoryID = Convert.ToInt32(Console.ReadLine());

            productService.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        static void EditProduct()
        {
            Console.Write("Enter product ID to edit: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product existingProduct = productService.GetProductById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter product name: ");
            existingProduct.Name = Console.ReadLine();

            Console.Write("Enter product Price: ");
            existingProduct.Price = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter product description: ");
            existingProduct.Description = Console.ReadLine();

            Console.Write("Enter CategoryId: ");
            existingProduct.CategoryID = Convert.ToInt32(Console.ReadLine());

            productService.EditProduct(existingProduct);
            Console.WriteLine("Product edited successfully.");
        }

        static void DeleteProduct()
        {
            Console.Write("Enter product ID to delete: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product existingProduct = productService.GetProductById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            productService.DeleteProduct(productId);
            Console.WriteLine("Product deleted successfully.");
        }

        static void GetProductById()
        {
            Console.Write("Enter product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product product = productService.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            //******************Display Product in Json Format***********************
            string JsonProduct = JsonConvert.SerializeObject(product);
            Console.WriteLine(JsonProduct);
            //**********************************************************************

            //Console.WriteLine($"Product ID: {product.Id}");
            //Console.WriteLine($"Product Name: {product.Name}");
            //Console.WriteLine($"Product Price: {product.Price}");
            //Console.WriteLine($"Product Description: {product.Description}");
            //Console.WriteLine($"Product CategoryID: {product.CategoryID}");
        }

        static void GetAllProducts()
        {
            List<Product> products = productService.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("********************All Products:********************");
            foreach (Product product in products)
            {
                Console.WriteLine(JsonConvert.SerializeObject(product));
                //Console.WriteLine($"Product ID: {product.Id}");
                //Console.WriteLine($"Product Name: {product.Name}");
                //Console.WriteLine($"Product Price: {product.Price}");
                //Console.WriteLine($"Product Description: {product.Description}");
                //Console.WriteLine($"Product CategoryID: {product.CategoryID}");
                Console.WriteLine();
            }
            Console.WriteLine("***************************************************");
        }

        #endregion
        //***********************************************
        #region Category Methods

        static void AddCategory()
        {
            Category category = new Category();

            Console.Write("Enter category ID: ");
            category.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter category name: ");
            category.Name = Console.ReadLine();
            categoryService.AddCategory(category);
            Console.WriteLine("Category added successfully.");
        }

        static void EditCategory()
        {
            Console.Write("Enter Category ID to Edit: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Category existingCategory = categoryService.GetCategoryById(categoryId);
            if (existingCategory == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Console.Write("Enter new category name: ");
            existingCategory.Name = Console.ReadLine();


            categoryService.EditCategory(existingCategory);
            Console.WriteLine("Category edited successfully.");
        }

        static void DeleteCategory()
        {
            Console.Write("Enter category ID to Delete: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Category existingCategory = categoryService.GetCategoryById(categoryId);
            if (existingCategory == null)
            {
                Console.WriteLine("Category Not Found.");
                return;
            }

            categoryService.DeleteCategory(categoryId);
            Console.WriteLine("Category Deleted Successfully.");
        }

        static void GetCategoryById()
        {
            Console.Write("Enter category ID: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Category category = categoryService.GetCategoryById(categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            //******************Display Product in Json Format***********************
            string JsonCategory = JsonConvert.SerializeObject(category);
            Console.WriteLine(JsonCategory);
            //**********************************************************************
            //Console.WriteLine($"Category ID: {category.Id}");
            //Console.WriteLine($"Category Name: {category.Name}");
        }

        static void GetAllCategories()
        {
            List<Category> categories = categoryService.GetAllCategories();
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories found.");
                return;
            }
            Console.WriteLine("********************All Categories:********************");

            foreach (Category category in categories)
            {
                //******************Display Product in Json Format***********************
                string JsonProduct = JsonConvert.SerializeObject(category);
                Console.WriteLine(JsonProduct);
                //**********************************************************************
                //Console.WriteLine($"Category ID: {category.Id}");
                //Console.WriteLine($"Category Name: {category.Name}");
                Console.WriteLine();
            }
            Console.WriteLine("********************************************************");
        }

        #endregion
    }
}