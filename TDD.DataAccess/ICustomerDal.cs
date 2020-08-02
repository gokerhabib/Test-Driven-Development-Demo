using System.Collections.Generic;
using TDD.Entities;

namespace TDD.DataAccess
{
    public interface ICustomerDal
    {
       List<Customer> GetAll();
    }
}