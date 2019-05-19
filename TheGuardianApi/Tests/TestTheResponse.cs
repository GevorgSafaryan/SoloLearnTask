using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheGuardianApi.ApiConsumer.Helpers;
using TheGuardianApi.ApiConsumer.Models;
using TheGuardianApi.ApiConsumer.Processors;

namespace TheGuardianApi.Tests
{
    public class TestTheResponse
    {
        List<ThumbnailModel> thumbnails;
        List<string> sections;
        int pageSize;


        [OneTimeSetUp]
        public async Task Setup()
        {
            ApiHelper.InitializeClient();
            thumbnails = await GetThumbnailProcessor.GetThumbnail();
            pageSize = await GetThumbnailProcessor.GetPageSize();
            sections = await FilterBySectionProcessor.GetSections(GetThumbnailProcessor.Section);
        }

        [Test]
        public void Thumbnails()
        {
            Assert.AreEqual(pageSize, thumbnails.Count);
            foreach (var thumbnail in thumbnails)
            {
                Assert.IsNotNull(thumbnail);
            }
        }

        [Test]
        public void FilterBySection()
        {
            foreach (string section in sections)
            {
                Assert.AreEqual(section, GetThumbnailProcessor.Section);
                Assert.IsNotNull(section);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ApiHelper.DisposeClient();
        }
    }
}
