<<<<<<< HEAD
﻿//using NUnit.Framework;
//using Moq;
//using FluentAssertions;
//using TPC_UPC.Domain.Models;
//using TPC_UPC.Domain.Services.Communications;
//using TPC_UPC.Domain.Persistence.Repositories;
//using TPC_UPC.Domain.Services;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using TPC_UPC.Services;

//namespace TPC_UPC.API.Test
//{
//    class UserServiceTest
//    {
//        [SetUp]
//        public void Setup()
//        {

//        }

//        [Test]
//        public async Task GetAsyncTestHappy()
//        {
//            // Arrange
//            var mockUserRepository = GetDefaultIUserRepositoryInstance();
//            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            int userId = 1;
//            User user = new Tutor();
//            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

//            mockUserRepository.Setup(r => r.FindById(userId))
//                .Returns(Task.FromResult<User>(user));

//            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);

//            // Act
//            UserResponse result = await service.GetByIdAsync(userId);

//            // Assert
//            Assert.AreEqual(user, result.Resource);
//        }

//        [Test]
//        public async Task PostAsyncTestHappy()
//        {
//            //
//            var mockUserRepository = GetDefaultIUserRepositoryInstance();
//            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            int userId = 1;
//            User user = new Tutor();
//            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

//            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);

//            UserResponse result = await service.SaveAsync(user);
=======
﻿using NUnit.Framework;
using Moq;
using FluentAssertions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using TPC_UPC.Services;

namespace TPC_UPC.API.Test
{
    class UserServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            int userId = 1;
            User user = new Tutor();
            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

            mockUserRepository.Setup(r => r.FindById(userId))
                .Returns(Task.FromResult<User>(user));

            var service = new UserService(mockUserRepository.Object,null, mockIUnitOfWork.Object);

            // Act
            UserResponse result = await service.GetByIdAsync(userId);

            // Assert
            Assert.AreEqual(user, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            //
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            int userId = 1;
            User user = new Tutor();
            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

            var service = new UserService(mockUserRepository.Object, null, mockIUnitOfWork.Object);

            UserResponse result = await service.SaveAsync(user);
>>>>>>> feature/businessrules-rodrigo
            
//            Assert.AreEqual(user, result.Resource);
//        }

//        [Test]
//        public async Task DeleteAsyncTestHappy()
//        {
//            // Arrange
//            var mockUserRepository = GetDefaultIUserRepositoryInstance();
//            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            int userId = 1;
//            User user = new Tutor();
//            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

//            mockUserRepository.Setup(r => r.FindById(userId))
//                .Returns(Task.FromResult<User>(user));

<<<<<<< HEAD
//            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);
=======
            var service = new UserService(mockUserRepository.Object, null, mockIUnitOfWork.Object);
>>>>>>> feature/businessrules-rodrigo

//            // Act
//            UserResponse result = await service.DeleteAsync(userId);

//            // Assert
//            Assert.AreEqual(user, result.Resource);
//        }

<<<<<<< HEAD
//        [Test]
//        public async Task PutAsyncTest()
//        {
//            // Arrange
//            var mockUserRepository = GetDefaultIUserRepositoryInstance();
//            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            int userId = 1;
//            User user = new Tutor();
//            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";

//            User expected = new Tutor();
//            expected.FirstName = "Lucas"; user.LastName = "Moreno";expected.Mail = "lucasmoreno@hotmail.com"; expected.PhoneNumber = "962783098";
=======
        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();

            int userId = 1;
            User user = new Tutor();
            user.Id = userId; user.FirstName = "Rodrigo"; user.LastName = "Calle"; user.Mail = "rcg@gmail.com"; user.PhoneNumber = "999233124";
            user.AccountId = 1;

            User expected = new Tutor();
            expected.Id = userId;
            expected.FirstName = "Lucas"; expected.LastName = "Moreno";expected.Mail = "lucasmoreno@hotmail.com"; expected.PhoneNumber = "962783098";
            expected.AccountId = 1;
>>>>>>> feature/businessrules-rodrigo

//            mockUserRepository.Setup(r => r.FindById(userId))
//                .Returns(Task.FromResult<User>(user));

<<<<<<< HEAD
//            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);
=======
            var service = new UserService(mockUserRepository.Object, mockUserCourseRepository.Object, mockIUnitOfWork.Object);
>>>>>>> feature/businessrules-rodrigo

//            // Act
//            UserResponse result = await service.UpdateAsync(userId, expected);

<<<<<<< HEAD
//            // Assert
//            Assert.AreEqual(expected.FirstName,result.Resource.FirstName);
//            Assert.AreEqual(expected.LastName, result.Resource.LastName);
//            Assert.AreEqual(expected.Mail, result.Resource.Mail);
//            Assert.AreEqual(expected.PhoneNumber, result.Resource.PhoneNumber);
//        }
=======
            // Assert
            Assert.AreEqual(expected.AccountId, result.Resource.AccountId);
            Assert.AreEqual(expected.FirstName,result.Resource.FirstName);
            Assert.AreEqual(expected.LastName, result.Resource.LastName);
            Assert.AreEqual(expected.Mail, result.Resource.Mail);
            Assert.AreEqual(expected.PhoneNumber, result.Resource.PhoneNumber);
        }
>>>>>>> feature/businessrules-rodrigo

//        [Test]
//        public async Task GetAsyncTestUnhappy()
//        {
//            // Arrange
//            var mockUserRepository = GetDefaultIUserRepositoryInstance();
//            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            int userId = 1;

<<<<<<< HEAD
//            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);
=======
            var service = new UserService(mockUserRepository.Object, null, mockIUnitOfWork.Object);
>>>>>>> feature/businessrules-rodrigo

//            // Act
//            UserResponse result = await service.GetByIdAsync(userId);
//            var message = result.Message;

//            // Assert
//            message.Should().Be("User not found");
//        }



<<<<<<< HEAD
//        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
//        {
//            return new Mock<IUserRepository>();
//        }
        
//        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
//        {
//            return new Mock<IUnitOfWork>();
//        }
//    }
//}
=======
        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUserCourseRepository> GetDefaultIUserCourseRepositoryInstance()
        {
            return new Mock<IUserCourseRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
>>>>>>> feature/businessrules-rodrigo
