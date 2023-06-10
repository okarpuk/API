using AngleSharp.Text;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class TestCases : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public int testCaseId { get; set; }

        [Test, Order(1)]
        public void AddCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = "Oleg's test";
            var actualCase = _caseService.AddCase(expectedCase, 1);

            var jsonObject = JObject.Parse(actualCase.Content);
            testCaseId = jsonObject.SelectToken("$.id").Value<int>();

            string actualTitle = jsonObject.SelectToken("$.title").Value<string>();
            _logger.Info("Actual test case title: " + actualTitle);

            Assert.That(actualTitle, Is.EqualTo(expectedCase.Title));
        }

        [Test, Order(2)]
        public void GetCaseTest()
        {
            var actualCase = _caseService.GetCase(testCaseId);

            var jsonObject = JObject.Parse(actualCase.Content);

            int actualId = jsonObject.SelectToken("$.id").Value<int>();

            Assert.That(actualId, Is.EqualTo(testCaseId));
        }

        [Test, Order(3)]
        public void UpdateCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = "Updated Oleg's case";
            expectedCase.SectionId = 2;

            var actualCase = _caseService.UpdateCase(expectedCase, testCaseId);

            var jsonObject = JObject.Parse(actualCase.Content);

            string actualTitle = jsonObject.SelectToken("$.title").Value<string>();
            _logger.Info("Actual test case title: " + actualTitle);

            int actualSectionId = jsonObject.SelectToken("$.section_id").Value<int>();
            _logger.Info("Actual test case ID: " + actualSectionId);

            Assert.Multiple(() =>
            {
                Assert.That(actualTitle, Is.EqualTo(expectedCase.Title));
                Assert.That(actualSectionId, Is.EqualTo(expectedCase.SectionId));
            });
        }

        [Test, Order(4)]
        public void DeleteCaseTest()
        {
            var actualCase = _caseService.DeleteCase(testCaseId);

            Assert.That("OK", Is.EqualTo(actualCase.StatusCode.ToString()));
        }
    }
}
