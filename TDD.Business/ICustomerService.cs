using System.Collections.Generic;
using TDD.Entities;

namespace TDD.Business
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<Customer> GetCustomersByInitial(string initial);
    }
}