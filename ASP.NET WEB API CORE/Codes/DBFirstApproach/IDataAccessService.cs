using DAL;
namespace DBFirstApproach
{
    public interface IDataAccessService
    {
        List<Customer>GetAllCustomers();
        List<Order> GetAllOrders();
        void AddCustomer(Customer Newcustomer);
        Customer GetCustomerByID(int CustomerID);
        List<Customer> GetCustomerByLoc(string loc);
        List<Customer> GetCustomerByChar(string sw);

        Customer GetCustomerByOrderID(int id);
        ICollection<Order> GetOrdersbyCustomerID(int id);

        Customer EditCustomer(Customer Customer);

        String[] Getlocations();

        Customer FindCustomer(int id);
    }
}
