using DataTransferObjects;
using Domain;
using Mapping.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mapper.Tests.Standard
{
    [TestClass]
    public class UserMappingTests
    {
        [TestInitialize]
        public void Initialise()
        {
            BootStrapper.Init();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            AutoMapper.Mapper.Reset();
        }

        [TestMethod]
        public void Ensure_UserDto_Address_is_flattened()
        {
            var user = new User
            {
                Name = "Bob",
                Address = new Address
                {
                    Address1 = "Address1"
                },
                Permissions = new Permission[0]
            };

            var dto = AutoMapper.Mapper.Map<UserDto>(user);

            Assert.AreEqual("Bob", dto.Name);
            Assert.AreEqual("Address1", dto.Address);
        }

        [TestMethod]
        public void Ensure_UserDto_Permissions_are_flattened()
        {
            var user = new User
            {
                Name = "Bob",
                Address = new Address(),
                Permissions = new[]
                {
                    new Permission {Name = "User"},
                    new Permission {Name = "Admin"}
                }
            };

            var dto = AutoMapper.Mapper.Map<UserDto>(user);

            Assert.AreEqual("Bob", dto.Name);
            Assert.AreEqual("Admin, User", dto.Permissions);
        }
    }
}