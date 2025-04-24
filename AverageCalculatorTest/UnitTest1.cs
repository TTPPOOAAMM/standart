using Xunit;
public class AverageCalculatorTests
{
    [Fact]
    public void NormalArray_ReturnsCorrectAverage()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        double result = AverageCalculator.CalculateAverage(array, 5);
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void SingleElementArray_ReturnsElementValue()
    {
        int[] array = { 10 };
        double result = AverageCalculator.CalculateAverage(array, 1);
        Assert.Equal(10.0, result);
    }

    [Fact]
    public void LargeNumbers_NoOverflow()
    {
        int[] array = { int.MaxValue, int.MaxValue };
        double result = AverageCalculator.CalculateAverage(array, 2);
        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void NullArray_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            AverageCalculator.CalculateAverage(null, 0));
    }

    [Fact]
    public void ZeroSize_ThrowsArgumentException()
    {
        int[] array = { 1, 2, 3 };
        Assert.Throws<ArgumentException>(() =>
            AverageCalculator.CalculateAverage(array, 0));
    }

    [Fact]
    public void SizeExceedsArrayLength_ThrowsArgumentException()
    {
        int[] array = new int[5];
        Assert.Throws<ArgumentException>(() =>
            AverageCalculator.CalculateAverage(array, 10));
    }
}
