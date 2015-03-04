using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Sync.Tests
{
    [TestFixture]
    public class SyncClientTests
    {
        [Test]
        [Category("WithExternalResource")]
        public async void testApiCall()
        {
            var syncClient = new MensaKLSyncClient();
            syncClient.APIUrl = "http://www.mensa-kl.de/?mode=mensaxml";
            string result = await syncClient.getApiCallResult();
            Assert.That(result, Is.StringStarting(@"<?xml version=""1.0"" encoding=""UTF-8""?><mensa>"));
        }
    }
}
