public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Métodos abstractos que deben ser implementados por cada actividad derivada
    public abstract double GetDistance(); // En millas
    public abstract double GetSpeed();    // En mph
    public abstract double GetPace();     // En min por milla

    // Método virtual para generar el resumen estándar
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min)- Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
