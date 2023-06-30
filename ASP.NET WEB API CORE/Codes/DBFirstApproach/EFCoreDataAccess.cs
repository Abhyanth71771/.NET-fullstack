using DAL;
using System.Collections.Generic;

namespace DBFirstApproach
{
    public class EFCoreDataAccess : IDataAccessService
    {
        private AspnetwebapidbContext context;

        public EFCoreDataAccess(AspnetwebapidbContext context)
        {
            this.context = context;
        }

        public void AddCustomer(Customer Newcustomer)
        {
            this.context.Customers.Add(Newcustomer);
            this.context.SaveChanges();


        }

        public Customer EditCustomer(Customer Customer)
        {
            var existingcust=this.context.Customers.Where(c=>c.Custid==Customer.Custid).FirstOrDefault();
            if (existingcust!=null)
            {
                existingcust.Custname = Customer.Custname;
                existingcust.Custid = Customer.Custid;
                existingcust.Location= Customer.Location;
                this.context.SaveChanges();
                
            }
            return Customer;

        }

        public Customer FindCustomer(int id)
        {
            var cust=context.Customers.Find(id);
            return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            return this.context.Customers.ToList();
        }

        public List<Order> GetAllOrders()
        {
            return this.context.Orders.ToList();
        }

        public List<Customer> GetCustomerByChar(string sw)
        {
            return this.context.Customers.Where(c => c.Custname.StartsWith(sw)).ToList();
        }

        //public System.Linq.IQueryable<DAL.Customer> GetCustomerByID(int CustomerID)
        //{
        //    return this.context.Customers.Where(c => c.Custid == CustomerID);
        //}
        public Customer GetCustomerByID(int CustomerID)
        {
            return this.context.Customers.Where(c => c.Custid == CustomerID).SingleOrDefault();
        }

        public List<Customer> GetCustomerByLoc(string loc)
        {
            return this.context.Customers.Where(c => c.Location.ToLower() == loc.ToLower()).ToList();
        }

        public Customer GetCustomerByOrderID(int id)
        {


            var order = context.Orders.Find(id);

            context.Entry(order).Reference(ord => ord.Cust).Load();

            return (Customer)order.Cust;



        }

        public string[] Getlocations()
        {
            return this.context.Customers.Select(c => c.Location).ToArray();    
        }

        public ICollection<Order> GetOrdersbyCustomerID(int id)
        {
            var cust = context.Customers.Find(id);

            context.Entry(cust).Collection(cust => cust.Orders).Load();

            return cust.Orders;
        }

        


     }
}
