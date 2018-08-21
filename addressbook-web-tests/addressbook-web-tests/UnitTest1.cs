using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 1500;
            bool vipCl = true;

            if (total > 1000 && vipCl)
            {
                total = total * 0.9;
                Console.Out.Write("Ваша скидка 10% , общая сумма: " + total);
            }
            else
                Console.Out.Write("Скидок нет");

        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] s = new string[] { "I","Want","to", "Sleep"};
            
            foreach(string element in s) //for (int i = 0; i < s.Length; i++ )
            {
                Console.Out.Write(element + "\n");
            }

        }




    }
}
