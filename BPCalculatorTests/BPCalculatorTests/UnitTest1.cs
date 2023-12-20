using BPCalculator;
using System.ComponentModel.DataAnnotations;

namespace BPCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Category_LowBloodPressure()
        {
            // Arrange
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 80,
                Diastolic = 50
            };

            // Act
            BPCategory category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        [TestMethod]
        public void Category_IdealBloodPressure()
        {
            // Arrange
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 110,
                Diastolic = 70
            };

            // Act
            BPCategory category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [TestMethod]
        public void Category_PreHighBloodPressure()
        {
            // Arrange
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 130,
                Diastolic = 85
            };

            // Act
            BPCategory category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        public void Category_HighBloodPressure()
        {
            // Arrange
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 150,
                Diastolic = 95
            };

            // Act
            BPCategory category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        public void TestInvalidSystolicValue()
        {
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = 200,
                Diastolic = 80
            };

            // Act & Assert
            var validationResults = ValidateModel(bloodPressure);
            Assert.IsTrue(validationResults.Count > 0);
            Assert.AreEqual("Invalid Systolic Value", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void TestInvalidDiastolicValue()
        {
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = 120,
                Diastolic = 110
            };

            // Act & Assert
            var validationResults = ValidateModel(bloodPressure);
            Assert.IsTrue(validationResults.Count > 0);
            Assert.AreEqual("Invalid Diastolic Value", validationResults[0].ErrorMessage);
        }


        private static List<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, results, true);
            return results;
        }
    }
}