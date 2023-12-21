using System;
using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace YourNamespace
{
    [Binding]
    public class BloodPressureCalculationStepFlow
    {
        private BloodPressure bloodPressure;
        private BPCategory resultCategory;

        [Given(@"the systolic value is below 90 and diastolic value is below 60")]
        public void GivenTheSystolicValueIsBelowAndDiastolicValueIsBelow()
        {
            bloodPressure = new BloodPressure { Systolic = 89, Diastolic = 59 };
        }

        [Given(@"the systolic value is 100 and the diastolic value is 70")]
        public void GivenTheSystolicValueIsAndTheDiastolicValueIs()
        {
            bloodPressure = new BloodPressure { Systolic = 100, Diastolic = 70 };
        }

        [Given(@"the systolic value is between 120 and 139 or diastolic value is between 80 and 89")]
        public void GivenTheSystolicValueIsBetweenAndDiastolicValueIsBetweenAnd()
        {
            bloodPressure = new BloodPressure { Systolic = 130, Diastolic = 85 };
        }

        [Given(@"the systolic value is between 140 and 190 or diastolic value is between 90 and 100")]
        public void TheSystolicValueIsBetweenAndDiastolicValueIsBetweenAnd()
        {
            bloodPressure = new BloodPressure { Systolic = 150, Diastolic = 95 };
        }

        [Given(@"the systolic value is 200 and diastolic value is 30")]
        public void GivenTheSystolicValueIsAndDiastolicValueIs()
        {
            bloodPressure = new BloodPressure { Systolic = 200, Diastolic = 30 };
        }

        [When(@"I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            resultCategory = bloodPressure.Category;
        }

        [Then(@"the result should be Low")]
        public void ThenTheResultShouldBeLow()
        {
            Assert.AreEqual(BPCategory.Low, resultCategory);
        }

        [Then(@"the result should be Ideal")]
        public void ThenTheResultShouldBeIdeal()
        {
            Assert.AreEqual(BPCategory.Ideal, resultCategory);
        }

        [Then(@"the result should be PreHigh")]
        public void ThenTheResultShouldBePreHigh()
        {
            Assert.AreEqual(BPCategory.PreHigh, resultCategory);
        }

        [Then(@"the result should be High")]
        public void ThenTheResultShouldBeHigh()
        {
            Assert.AreEqual(BPCategory.High, resultCategory);
        }
       
    }
}
