using AccuWeatherSpFl.Actions;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AccuWeatherSpFl.Steps
{
    [Binding]
    public class GetCitySteps
    {
        ApiActions api = new ApiActions();
        CityActions city = new CityActions();
        string _code;
        string _actualResult;

        [Given(@"the country code ""(.*)""")]
        public void GivenTheCountryCode(string code)
        {
            _code = code;
        }
        
        [When(@"requesting Admin Area List")]
        public void WhenRequestingAdminAreaList()
        {
            _actualResult = city.GetName(api.GetCities(_code).First());
        }
        
        [Then(@"the first city should be ""(.*)""")]
        public void ThenTheFirstCityShouldBe(string expectedResult)
        {
            Assert.That(_actualResult, Contains.Substring(expectedResult));
        }
    }
}
