using BugSplatDotNetStandard;
using NUnit.Framework;
using System;
using System.Net;

namespace Tests
{
    public class BugSplatTest
    {

        [Test]
        public void BugSplat_Post_ShouldPostExceptionToBugSplat()
        {
            try
            {
                throw new Exception("BugSplat!");
            }
            catch (Exception ex)
            {
                var sut = new BugSplat("octomore", "MyUwpCrasherTest", "1.0.0.0");

                var response = sut.Post(ex).Result;
                var body = response.Content.ReadAsStringAsync().Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}