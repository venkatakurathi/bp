using BPCalculator;
using System.ComponentModel.DataAnnotations;

[TestClass]
public class BPCalcuatorUnitTests
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
    [ExpectedException(typeof(ValidationException), "Invalid Systolic Value")]
    public void InvalidSystolicValue()
    {
        // Arrange
        BloodPressure bloodPressure = new BloodPressure
        {
            Systolic = 200,
            Diastolic = 70
        };

        // Act
        // ValidationException is expected to be thrown
        BPCategory category = bloodPressure.Category;
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException), "Invalid Diastolic Value")]
    public void InvalidDiastolicValue()
    {
        // Arrange
        BloodPressure bloodPressure = new BloodPressure
        {
            Systolic = 120,
            Diastolic = 110
        };

        // Act
        // ValidationException is expected to be thrown
        BPCategory category = bloodPressure.Category;
    }
}
