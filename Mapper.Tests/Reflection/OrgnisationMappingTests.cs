using DataTransferObjects;
using Domain;
using Mapping.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mapper.Tests.Reflection
{
    [TestClass]
    public class OrgnisationMappingTests
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
        public void Ensure_Organisations_can_be_flattened()
        {
            var org = new Organisation
            {
                Name = "Bobs Used Cars",
                PrimaryAddress = new Address {Address1 = "Boar Lane", Postcode = "LS11LS"},
                Addresses = new[]
                {
                    new Address {Address1 = "Boar Lane", Postcode = "LS11LS"},
                    new Address {Address1 = "Call Lane", Postcode = "LS11LS"},
                    new Address {Address1 = "Bobstown", Postcode = "LS22LS"}
                },
                Users = new[]
                {
                    new User {Name = "Bob McBob"},
                    new User {Name = "Steve McSteveson"}
                }
            };
            var dto = AutoMapper.Mapper.Map<OrganisationDto>(org);

            Assert.AreEqual("Bobs Used Cars", dto.Name);
            Assert.AreEqual("Boar Lane, LS11LS", dto.PrimaryAddress);
            Assert.AreEqual("Boar Lane, LS11LS\r\nCall Lane, LS11LS\r\nBobstown, LS22LS", dto.Addresses);
            Assert.AreEqual(2, dto.UsersCount);
            Assert.AreEqual("Bob McBob, Steve McSteveson", dto.Users);
        }
    }
}