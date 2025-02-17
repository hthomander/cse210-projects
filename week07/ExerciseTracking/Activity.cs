using System;


public abstract class Activity
{
    protected DateTime _date;
    protected int _duration; 

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetActivityType()} - {_date: dd MMM yyyy} - {_duration} min - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min/mile";
    }

    public virtual string GetActivityType()
    {
        return "Activity";
    }

}