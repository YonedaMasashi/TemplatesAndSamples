using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utf8JsonSampleh
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var root = new Dictionary<string, object>();

            var child = new List<object>();
            foreach (var i in Enumerable.Range(1, 10))
            {
                child.Add(i);
            }

            root.Add("Root", child);

            var hoge = Utf8Json.JsonSerializer.ToJsonString(root);
            

            Assert.AreEqual("", hoge);
        }
    }
}
