using System;

public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // distance = speed * hours
        double hours = GetMinutes() / 60.0;
        return _speed * hours;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
