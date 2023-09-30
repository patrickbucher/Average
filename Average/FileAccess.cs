namespace Average;

public class FileAccess {
    public static List<int> ReadNumbers(string path) {
        if (!File.Exists(path)) {
            throw new FileNotFoundException("Die Datei existiert nicht.");
        }

        var numbers = File.ReadLines(path)
            .Select((line, index) => {
                if (!int.TryParse(line, out var number))
                    throw new FormatException(
                        "Die Datei enthält ungültige Zeichen.");
                return number;
            })
            .ToList();

        if (numbers.Count == 0) {
            throw new InvalidOperationException("Die Datei ist leer.");
        }

        return numbers;
    }
}