using System;
using System.Collections.Generic;
using AnalyticsPortal.ServiceModel.Types;
using NUnit.Framework;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.PostgreSQL;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace GcomprisBackend.IntegrationTests
{
    /// <summary>
    /// This tests the Summary Service interface - 
    /// </summary>
    [TestFixture]
    public class SummaryServiceTests : BaseTests
    {
        private const string SummaryResource = "summary";
        private const string TestStudentLogin = "test";
        private string _summaryResourceUrl;

        [SetUp]
        public void Setup ()
        {
            //OrmLiteConfig.DialectProvider = PostgreSQLDialectProvider.Instance;
            _summaryResourceUrl = string.Format("{0}{1}", ListeningOn, SummaryResource);
        }

        [Test]
        public void TestReturnsValue()
        {
            var client = new JsonServiceClient();

            var summaryResponse =
                client.Get<List<ActivitySummaryResult>>(string.Format("{0}/{1}", _summaryResourceUrl, TestStudentLogin));

            Console.WriteLine("Json data received: {0}", summaryResponse.ToJson());
        }
    }
}