using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using beta.TheSoundOf.net;
using beta.TheSoundOf.net.Models;

namespace beta.TheSoundOf.net.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_save_child_with_parent()
        {


            using (var db = new DB())
            {
                var p = new Producer();
                p.Name = "demo 123";
                var s = new Show() { Producer =  p, Title="And we have a title" };

                db.Producers.Add(p);
                db.SaveChanges();

                Assert.AreNotEqual(p.Id, 0);
                Assert.AreNotEqual(s.Id, 0);

            }
        }
    }
}
