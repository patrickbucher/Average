namespace Average;

public class Average {

    private readonly Statistics _statistics = new();
    
    public double ComputeMeanOfFile(string path)
    {
        var numbers = FileAccess.ReadNumbers(path);
        return _statistics.Mean(numbers);
    }
    
    public double ComputeMedianOfFile(string path)
    {
        var numbers = FileAccess.ReadNumbers(path);
        return _statistics.Median(numbers);
    }
    
    public List<int> ComputeModeOfFile(string path)
    {
        var numbers = FileAccess.ReadNumbers(path);
        return _statistics.Mode(numbers);
    }
}
