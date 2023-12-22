using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using BPCalculator.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace BPCalculator.Tests
{   
    [TestClass]
    public class BloodPressureTests
    {

        [TestMethod]
        public void TestLowBloodPressures()
        {
            Random random = new();
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(70, 89),
                Diastolic = random.Next(40, 59)
            };

            // Act
            var category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, category);
        }

        [TestMethod]
        public void TestIdealBloodPressures()
        {
            Random random = new();
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(90, 119),
                Diastolic = random.Next(60, 79)
            };

            // Act
            var category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [TestMethod]
        public void TestPreHighBloodPressure()
        {
            Random random = new();
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(120, 139),
                Diastolic = random.Next(80, 89)
            };

            // Act
            var category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [TestMethod]
        public void TestHighBloodPressure()
        {
            Random random = new();
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(140, 190),
                Diastolic = random.Next(90, 100)
            };

            // Act
            var category = bloodPressure.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, category);
        }

        [TestMethod]
        public void TestInvalidSystolicValue()
        {
            Random random = new();
            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(70,190) + 121,
                Diastolic = random.Next(40,100)
            };

            // Act & Assert
            var validationResults = ValidateModel(bloodPressure);
            Assert.IsTrue(validationResults.Count > 0);
            Assert.AreEqual("Invalid Systolic Value", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void SystolicAlwaysGreater()
        {
            var bloodPressure = new BloodPressure
            {
                Systolic = 30,
                Diastolic = 50
            };
            var validationResults = ValidateModel(bloodPressure);
            Assert.IsTrue(validationResults.Count > 0);
            Assert.AreEqual("Invalid Systolic Value", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void TestInvalidDiastolicValue()
        {
            Random random = new();

            // Arrange
            var bloodPressure = new BloodPressure
            {
                Systolic = random.Next(70, 190),
                Diastolic = random.Next(40, 100) + 61
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

        [TestMethod]
        public void OnPost_ValidInput_ShouldReturnValidCategory()
        {
            // Arrange
            BloodPressureModel bloodPressureModel = new()
            {
                BP = new BloodPressure { Systolic = 120, Diastolic = 80 }
            }; // Use default constructor

            // Act
            IActionResult result = bloodPressureModel.OnPost();

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.AreEqual(BPCategory.PreHigh, bloodPressureModel.BP.Category);
        }

        [TestMethod]
        public void CreateHostBuilder_ShouldReturnIHostBuilder()
        {
            // Act
            var hostBuilder = Program.CreateHostBuilder(null);

            // Assert
            Assert.IsNotNull(hostBuilder);
            Assert.IsInstanceOfType(hostBuilder, typeof(IHostBuilder));
        }

    }
}