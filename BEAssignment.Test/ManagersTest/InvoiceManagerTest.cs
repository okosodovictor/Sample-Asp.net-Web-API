using System;
using BEAssignment.Core.Business;
using BEAssignment.Core.Interfaces.Managers;
using BEAssignment.Core.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BEAssignment.Core.Interfaces.DataAccess;
using System.Linq;

namespace BEAssignment.Test.ManagersTest
{
    [TestClass]
    public class InvoiceManagerTest
    {
        [TestMethod]
        public void CreateInvalidInvoiceFails()
        {
            //Arrange
            var mockRepo = new Mock<IInvoiceRepository>();

            //Setup Test Data
            var invoice = new InvoiceModel { };
            var manager = new InvoiceManager(mockRepo.Object);

            //Act
            var createInvoice = manager.CreateInvoice(invoice);

            //Assert
            Assert.IsFalse(createInvoice.Succeeded, "Invalid Invoice was Created");
        }

        [TestMethod]
        public void CreateValidInvoice()
        {
            //Arrange
            var mockRepo = new Mock<IInvoiceRepository>();

            //Setup Test Data
            var invoice = new InvoiceModel { AddressId = 1, InvoiceNumber = "Inv-001" };
            var manager = new InvoiceManager(mockRepo.Object);

            //Act
            var createInvoice = manager.CreateInvoice(invoice);

            //Assert
            Assert.IsTrue(createInvoice.Succeeded, createInvoice.Message);

            mockRepo.Verify(repo => repo.CreateInvoice(invoice), Times.Once);
        }

        [TestMethod]
        public void GetInvoiceByCustomerID()
        {
            //Arrange
            var mockRepo = new Mock<IInvoiceRepository>();
            var manager = new InvoiceManager(mockRepo.Object);

            //Setup Data
            var customerId = 1;
            var invoices = new[] { new InvoiceModel { InvoiceId = 1 }, new InvoiceModel { InvoiceId = 2 } };

            //Return Invoices from Query
            mockRepo.Setup(r => r.GetInvoicesByCustomerId(customerId)).Returns(invoices);
            
            //Act
            var getInvoices = manager.GetInvoiceByCustomerId(customerId);

            //Assert
            Assert.IsTrue(getInvoices.Succeeded, getInvoices.Message);
            Assert.IsTrue(getInvoices.Result.Length > 0);
            Assert.IsTrue(getInvoices.Result.SequenceEqual(invoices));
        }

        [TestMethod]
        public void GetInvoiceByAddressId()
        {
            //Arrange
            var mockRepo = new Mock<IInvoiceRepository>();
            var manager = new InvoiceManager(mockRepo.Object);
            //Setup Data
            var addressId = 1;
            var invoices = new[] { new InvoiceModel { InvoiceId = 1, AddressId=1 }, new InvoiceModel { InvoiceId = 2, AddressId =1}, new InvoiceModel { InvoiceId = 2, AddressId=2 } };

            //Return Invoices from Query
            mockRepo.Setup(r => r.GetInvoiceByAddressId(addressId)).Returns(invoices);

            //Act
            var getInvoices = manager.GetInvoiceByAddressId(addressId);

            //Assert
            Assert.IsTrue(getInvoices.Succeeded, getInvoices.Message);
            Assert.IsTrue(getInvoices.Result.Length > 0);
            Assert.IsTrue(getInvoices.Result.SequenceEqual(invoices));
        }
    }
}
