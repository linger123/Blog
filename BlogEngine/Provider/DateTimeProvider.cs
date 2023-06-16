namespace BlogEngine.Provider;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime DateProduction => DateTime.UtcNow;
}
