using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    struct CustomerDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

    class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public static implicit operator CustomerDTO(Customer customer)
        {
            var data = new CustomerDTO
            {
                Name = customer.Name,
                Age = customer.Age,
                Phone = customer.Phone
            };
            return data;
        }
    }

    public class CustomerSafeParams
    {
        private static void CustomerReference(Customer customer)
        {
            Random random = new Random();
            customer.Age = random.Next(1, 100);
        }

        private static void PrintCustomerData(Customer customer)
        {
            Console.WriteLine("Printing customer data....");
            Console.WriteLine("Name is: {0}", customer.Name);
            Console.WriteLine("Age is: {0}", customer.Age);
            Console.WriteLine("Phone is: {0}", customer.Phone);
            Console.WriteLine();
        }

        private static void ExecuteCustomerReference(Customer customer)
        {
            Task t1 = Task.Run(() => CustomerReference(customer));
            Task t2 = Task.Run(() => CustomerReference(customer));
            Task t3 = Task.Run(() => CustomerReference(customer));
            Task.WaitAll(t1, t2, t3);
            PrintCustomerData(customer);
        }

        private static void CustomerValue(CustomerDTO customer)
        {
            Random random = new Random();
            customer.Age = random.Next(1, 100);
        }

        private static void ExecuteCustomerValue(Customer customer)
        {
            CustomerDTO data = customer;
            Task t1 = Task.Run(() => CustomerValue(data));
            Task t2 = Task.Run(() => CustomerValue(data));
            Task t3 = Task.Run(() => CustomerValue(data));
            Task.WaitAll(t1, t2, t3);
            PrintCustomerData(customer);
        }

        public static bool Run()
        {
            Customer customer = new Customer
            {
                Name = "John",
                Age = 32,
                Phone = "4430307070"
            };
            ExecuteCustomerValue(customer);
            ExecuteCustomerReference(customer);
            return true;
        }
    }
}
