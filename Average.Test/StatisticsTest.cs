namespace Average.Test;

public class StatisticsTest {
    private readonly Statistics _sut = new();

    [Fact]
    public void Mean_WhenListOfNumbersIsEmptyThenThrowException() {
        List<int> numbers = new();

        var exception = Assert.ThrowsAny<ArgumentException>(() => { _sut.Mean(numbers); });

        Assert.Equal("cannot compute mean of an empty list", exception.Message);
    }


    [Fact]
    public void Mean_WhenListOfNumbersOnlyContainsOneElementThenReturnNumber() {
        var numbers = new List<int> { 11 };

        var actual = _sut.Mean(numbers);

        Assert.Equal(11, actual);
    }

    [Theory]
    [InlineData(new[] { -1, 0, 1 }, 0)]
    [InlineData(new[] { 10, 20, 30, 40, 50 }, 30)]
    [InlineData(new[] { 5, 2 }, 3.5)]
    public void Mean_WhenListOfNumbersContainsMultipleElementsThenReturnMean(int[] numbers, double expected) {
        var actual = _sut.Mean(numbers.ToList());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Median_WhenListOfNumbersIsEmptyThenThrowException() {
        List<int> numbers = new();

        var exception = Assert.ThrowsAny<ArgumentException>(() => { _sut.Median(numbers); });

        Assert.Equal("cannot compute median of an empty list", exception.Message);
    }

    [Fact]
    public void Median_WhenListOfNumbersOnlyContainsOneElementThenReturnNumber() {
        var numbers = new List<int> { 55 };

        var actual = _sut.Median(numbers);

        Assert.Equal(55, actual);
    }

    [Theory]
    [InlineData(new[] { -1, 0 }, -0.5)]
    [InlineData(new[] { 10, 20, 30, 40 }, 25)]
    [InlineData(new[] { 2, 5 }, 3.5)]
    [InlineData(new[] { 1, 2, 3, 4 }, 2.5)]
    public void Median_WhenListOfNumbersContainsEvenNumberOfElementsThenReturnMean(int[] numbers, double expected) {
        var actual = _sut.Median(numbers.ToList());

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] { -1, 0, 1 }, 0)]
    [InlineData(new[] { 10, 20, 30, 40, 50 }, 30)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
    public void Median_WhenListOfNumbersContainsUnevenNumberOfElementsThenReturnMean(int[] numbers, double expected) {
        var actual = _sut.Median(numbers.ToList());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Mode_WhenListOfNumbersIsEmptyThenThrowException() {
        List<int> numbers = new();

        var exception = Assert.ThrowsAny<ArgumentException>(() => { _sut.Mode(numbers); });

        Assert.Equal("cannot compute mode of an empty list", exception.Message);
    }

    [Fact]
    public void Mode_WhenListOfNumbersOnlyContainsOneElementThenReturnNumber() {
        var numbers = new List<int> { 55 };

        var actual = _sut.Mode(numbers);

        Assert.Equal(numbers, actual);
    }

    [Theory]
    [InlineData(new[] { -1, 0, 1 })]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new[] { 55, 60, 70 })]
    public void Mode_WhenListOfNumbersOnlyContainsUniqueElementsThenReturnMultipleNumbers(int[] numbers) {
        var actual = _sut.Mode(numbers.ToList());

        Assert.Equal(numbers, actual);
    }

    [Theory]
    [InlineData(new[] { -1, 0, 1, 1 }, 1)]
    [InlineData(new[] { 1, 2, 2, 3, 3, 3 }, 3)]
    [InlineData(new[] { 55, 60, 70, 55 }, 55)]
    public void Mode_WhenListOfNumbersContainsUniqueElementsAndOneDuplicateElementThenReturnNumber(int[] numbers,
        int expected) {
        var actual = _sut.Mode(numbers.ToList());

        Assert.Equal( new List<int> { expected }, actual);
    }
}