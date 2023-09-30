namespace Average.Test;

public class StatisticsIT : IDisposable {
    private readonly Average _sut = new();

    public void Dispose() {
        File.Delete(Path.Combine(Path.GetTempPath(), "numbers.txt"));
    }

    [Fact]
    public void ComputeMeanOfFile() {
        var tempFilePath = WriteTestNumbersToFile(1, 2, 3);
        var actual = _sut.ComputeMeanOfFile(tempFilePath);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void ComputeMedianOfFile() {
        var tempFilePath = WriteTestNumbersToFile(1, 3, 5, 7, 9);
        var actual = _sut.ComputeMedianOfFile(tempFilePath);
        Assert.Equal(5, actual);
    }

    [Fact]
    public void ComputeModeOfFile() {
        var tempFilePath = WriteTestNumbersToFile(1, 1, 2, 6, 7);
        var actual = _sut.ComputeModeOfFile(tempFilePath);
        Assert.Equal(new[] { 1 }, actual);
    }

    private string WriteTestNumbersToFile(params int[] numbers) {
        var tempFilePath = Path.Combine(Path.GetTempPath(), "numbers.txt");
        var writer = new StreamWriter(tempFilePath);

        foreach (var number in numbers) {
            writer.WriteLine(number);
        }
        writer.Close();
        return tempFilePath;
    }
}