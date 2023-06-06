List<Pathfinder> pathfinders = new List<Pathfinder>()
{
    new Pathfinder(new Logger(new FreeChecker(), new ConsoleWriter())),
    new Pathfinder(new Logger(new FridayChecker(), new ConsoleWriter())),
    new Pathfinder(new Logger(new FreeChecker(), new FileWriter())),
    new Pathfinder(new Logger(new FridayChecker(), new FileWriter())),
    new Pathfinder(new List<Logger>() {
        new Logger(new FridayChecker(), new FileWriter()),
        new Logger(new FreeChecker(), new ConsoleWriter())
        })
};

public interface ILogChecker
{
    public bool IsLoggingAllowed { get; }
}

public class FridayChecker: ILogChecker
{
    public bool IsLoggingAllowed => DateTime.Now.DayOfWeek == DayOfWeek.Friday;
}

public class FreeChecker: ILogChecker
{
    public bool IsLoggingAllowed => true;
}

public interface ILogWriter
{
    public void WriteError(string message);
}

public class FileWriter: ILogWriter
{
    public void WriteError(string message)
    {
        File.WriteAllText("log.txt", message);
    }
}

public class ConsoleWriter: ILogWriter
{
    public void WriteError(string message)
    {
        Console.WriteLine(message);
    }
}

public class Logger
{
    private ILogChecker _checker;
    private ILogWriter _writer;

    public Logger(ILogChecker checker, ILogWriter writer)
    {
        _checker = checker;
        _writer = writer;
    }

    public bool TryWriteError(string message)
    {
        if (_checker.IsLoggingAllowed)
        {
            _writer.WriteError(message);
            return true;
        }

        return false;
    }
}

public class Pathfinder
{
    private List<Logger> _loggers;

    public Pathfinder(Logger logger)
    {
        _loggers = new List<Logger>() { logger };
    }

    public Pathfinder(List<Logger> loggers)
    {
        _loggers = loggers;
    }

    public void Find()
    {
        foreach (Logger logger in _loggers)
        {
            logger.TryWriteError("Test log message");
        }
    }
}