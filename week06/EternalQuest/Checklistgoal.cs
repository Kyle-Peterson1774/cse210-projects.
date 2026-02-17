using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal is already complete. No points awarded.");
            return 0;
        }

        _amountCompleted++;

        int earned = _points;
        bool finishedNow = (_amountCompleted >= _target);

        if (finishedNow)
        {
            earned += _bonus;
            Console.WriteLine($"Boom. Completed! You earned {_points} points + {_bonus} bonus = {earned} points.");
        }
        else
        {
            Console.WriteLine($"Logged! You earned {_points} points. Progress: {_amountCompleted}/{_target}");
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
