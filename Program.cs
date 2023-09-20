using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics//Bunuda anlamadım ne olduğunu
{
    class Program
    {
        static void Main(string[] args)
        {
            Utulitiez utulitiez = new Utulitiez();
            List<string> result = utulitiez.BuildList<string>("İstanbul", "Ankara", "İzmir");//Gelen listeye her zaman string atar.
            foreach (var item in result)
            {
                Console.WriteLine(item + "\n");
            }

            List<Customer> result2 = utulitiez.BuildList<Customer>(new Customer { FirstName = "Cem" }, new Customer { FirstName = "Tamino" });
            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadKey();
        }
    }
    class Utulitiez
    {
        public List<T> BuildList<T>(params T[] items)//Generic Metot
        {
            return new List<T>(items);
        }
    }
    class Product
    {

    }
    interface IProductDal : IRepository<Product>
    {
        /*List<Product> GetAll();
        Product Get(int Id);

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);*/
    }
    class Customer
    {
        public string FirstName { get; set; }
    }
    interface ICustomerDal : IRepository<Customer>
    {//Product interface'i ile aynı alanlara sahip ama ayrı yazmak zorunda kaldık.
        /*List<Customer> GetAll();
        Customer Get(int Id);

        void Add(Customer product);
        void Update(Customer product);
        void Delete(Customer product);*/
        void Custom();
    }
    //Generic Kısıtlar
    interface IStudentDal : IRepository<Customer>
    {

    }
    class Student : IEntity
    {

    }
    interface IEntity
    {

    }
    interface IRepository<T> where T : class, IEntity, new()//Generics alanı böyle yazılıyor isimlendirme serbest type'ın kısaltılmışını yazdım, generic
    {
        List<T> GetAll();
        T Get(int Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
    class CustomerDal : ICustomerDal//Özel bir değişiklik yaptığımızda kolayca ekleyebilmemizi sağlıyor.
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
