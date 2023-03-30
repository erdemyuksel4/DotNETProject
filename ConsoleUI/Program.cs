using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Net.Http.Headers;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CateogoryTest();
        }

        private static void CateogoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if(result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+"/"+product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}