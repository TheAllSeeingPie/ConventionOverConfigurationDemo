using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tests
{
    [TestClass]
    public class ReflectionExamples
    {
        [TestMethod]
        public void Do_some_things_with_Reflection_on_JustANormalClass()
        {
            object instance = new JustANormalClass
            {
                Id = 1,
                Name = "Bob"
            };

            var type = instance.GetType();

            //Create an instance based on our type using default constructor
            var instance1 = Activator.CreateInstance(type);

            //Get the InternalId property even though it's Private
            var internalId = type.GetProperty("InternalId", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(0, internalId.GetValue(instance1));

            //Call a Protected method to set the InternalId
            var setInternalId = type.GetMethod("SetInternalId", BindingFlags.NonPublic | BindingFlags.Instance);
            setInternalId.Invoke(instance1, new object[] {1});
            Assert.AreEqual(1, internalId.GetValue(instance1));

            //Find the Name property and call it
            var name = type.GetProperty("Name");
            Assert.AreNotEqual("Bob", name.GetValue(instance1));

            //Copy name from instance to instance1
            name.SetValue(instance1, name.GetValue(instance));
            Assert.AreEqual("Bob", name.GetValue(instance1));

            //Create another instance using a type that was found with magic strings and using the overload constructor
            var type1 = Type.GetType("Demo.Tests.JustANormalClass");
            var instance2 = Activator.CreateInstance(type1, new object[] {"Bob"});
            Assert.AreEqual("Bob", name.GetValue(instance2));
        }
    }
}