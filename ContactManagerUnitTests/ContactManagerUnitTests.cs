using ContactManager.Controllers;
using ContactManager.Data.Repository.IRepository;
using ContactManager.Models;
using ContactManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactManagerUnitTests
{
    public class ContactManagerUnitTests
    {
        [Fact]
        public async Task TestAddContact()
        {
            Contact contact = new Contact
            {
                FirstName = "Joe",
                LastName = "Schmo",
                PhoneNumber = "555-555-5555",
                Email = "test@example.com",
                DateAdded = DateTime.Now,
            };

            var vm = new AddContactVM
            {
                Contact = contact
            };

            var mockRepo = new Mock<IContactRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Contacts).Returns(mockRepo.Object);

            var controller = new ContactController(unitOfWorkMock.Object);

            var result = controller.Add(vm);

            mockRepo.Verify(repo => repo.Add(contact), Times.Once());
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once());
            Assert.IsAssignableFrom<RedirectToActionResult>(result);            
        }

        [Fact]
        public async Task TestEditContact()
        {
            Contact contact = new Contact
            {
                FirstName = "Joe",
                LastName = "Schmo",
                PhoneNumber = "555-555-5555",
                Email = "test@example.com",
                DateAdded = DateTime.Now,
            };

            var mockRepo = new Mock<IContactRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Contacts).Returns(mockRepo.Object);

            var controller = new ContactController(unitOfWorkMock.Object);
            var result = controller.Edit(contact);

            mockRepo.Verify(repo => repo.Update(contact), Times.Once());
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once());
        }

        [Fact]
        public async Task TaskDeleteContact()
        {
            var mockRepo = new Mock<IContactRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Contacts).Returns(mockRepo.Object);

            var id = 2;
            var contact = unitOfWorkMock.Object.Contacts.GetFirstOrDefault(x => x.ContactId == id);

            var controller = new ContactController(unitOfWorkMock.Object);
            var result = controller.Delete(id);

            mockRepo.Verify(repo => repo.Remove(contact), Times.Once());
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once());
        }
    }
}
