using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TDD.DataAccess;
using TDD.Entities;

namespace TDD.Business.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        
        private Mock<ICustomerDal> _mockCustomerDal;
        private List<Customer> _dbCustomers;
        /// <summary>
        /// Her test'in başlangıcında çalışır Test Initialize
        /// </summary>
        [TestInitialize]
        public void Start()
        {
            _mockCustomerDal = new Mock<ICustomerDal>();
            _dbCustomers = new List<Customer>
            {
                new Customer{Id=1,FirstName="Ahmet"},
                new Customer{Id=2,FirstName="Mehmet"},
                new Customer{Id=3,FirstName="Ayşe"},
                new Customer{Id=4,FirstName="Fatma"},
                new Customer{Id=5,FirstName="Aydın"},
            };
            _mockCustomerDal.Setup(m => m.GetAll()).Returns(_dbCustomers);
        }
        /// <summary>
        /// Arrange Test ortamının oluşturulduğu ortam
        /// 2. Kısım aksiyon alınan kısım
        /// Assert Kısımıda sonucun test edildiği kısım
        /// </summary>
        [TestMethod]
        public void Tum_musteriler_listenebilmedilir()
        {
            //Arrange
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
            
            //2.
            List<Customer> customers = customerService.GetAll();
            
            //Assert
            Assert.AreEqual(5,customers.Count);
        }
        /// <summary>
        /// Arrange Test ortamının oluşturulduğu ortam
        /// 2. Kısım aksiyon alınan kısım
        /// Assert Kısımıda sonucun test edildiği kısım
        /// </summary>
        [TestMethod]
        public void A_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
           
            //2.
            List<Customer> customers = customerService.GetCustomersByInitial("A");
            
            //Assert
            Assert.AreEqual(3,customers.Count);
        }
        /// <summary>
        /// Arrange Test ortamının oluşturulduğu ortam
        /// 2. Kısım aksiyon alınan kısım
        /// Assert Kısımıda sonucun test edildiği kısım
        /// </summary>
        [TestMethod]
        public void Kucuk_A_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange
            ICustomerService _customerService = new CustomerManager(_mockCustomerDal.Object);
            
            //2
            List<Customer> customers = _customerService.GetCustomersByInitial("a");
            
            //Assert
            Assert.AreEqual(0,customers.Count);
        }
    }
}
//Müşteriler Listelenebilmelidir.
//Müşteriler baş harflerine göre sayfalanabilmelidir.
//TestCase
//5 elemanlı bir liste olsun