using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void Do_Hello_World()
        {
            object instance = new HelloWorld();
            Type type = instance.GetType();
            MethodInfo sayHello = type.GetMethod("SayHello");
            object instance1 = new HelloWorld();
            Assert.AreEqual("Hello World!", sayHello.Invoke(instance1, null));
        }
    }
}