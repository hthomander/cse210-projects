using System;

class Swimming : Activity
{
    public int _laps;
    private const double LapDistance = 50 * 0.000621371;
    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapDistance;
    public override double GetSpeed() => (GetDistance() / _duration) * 60;
    public override double GetPace() => _duration / GetDistance();

    public override string GetActivityType()
    {
        return "Swimming";
    }
   
}