using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelGry;

namespace UnitTestsProjectModelGry
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Losuj_Zakres_OK(int a,int b)
        {
            //AAA
            //Arrange
            int x = a;
            int y = b;

            //Act
            int los = Gra.Losuj(x, y);

            //Assert
            Assert.IsTrue(los >= Math.Min(x, y) && los <= Math.Max(x, y));


        }
    }
}
