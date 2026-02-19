using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double meters = _laps * 50.0;
        double km = meters / 1000.0;
        double miles = km * 0.621371;
        return miles;
    }
}
