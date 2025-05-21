using System;

public class Job
{
    public string _JobTitle;
    public string _CompanyName;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_JobTitle}  ({_CompanyName})  {_startYear} to {_endYear}");
    }
}