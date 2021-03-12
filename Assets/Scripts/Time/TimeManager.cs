using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : Singleton<TimeManager>
{
    const int timeUnit = 10;//10 min to najmniejsza jednostka czasu jak w stardew valley
    private int maxTime = 1440;//60*24
    private int timeNow = 0;
    private int hour;
    private int minutes;

    private Days day = Days.Monday;

    public System.Action OnDayEnds = delegate{};
    public System.Action<int,int> OnTimeChanged = delegate{};

    public int Hour { get => hour; private set => hour = value; }
    public int Minutes { get => minutes; private set => minutes = value; }
    public Days Day { get => day; private set => day = value; }

    public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

private void Update()
{
    if(Time.deltaTime > 10)
    {
        AddTime(timeUnit * 1);
    }
}

    private void UpdateTime()
    {
        Hour = timeNow / 60;
        Minutes = timeNow % 60;
        NotifyTimeChanged();
    }

    private void UpdateDay()
    {
        if(Day == Days.Sunday)
        {
            Day = Days.Monday;
        }
        else
        {
            Day++;
        }

        timeNow = 0;
        UpdateTime();
        NotifyDayEnd();
    }

    // protected override void Initialize()
    // {
    //     AttachEvents();
    // }

    // private void AttachEvents()
    // {
    //     OnDayEnds += UpdateDay;
    // }

    public void AddTime(int time)
    {
        timeNow += time;
        UpdateTime();

        if(timeNow >= maxTime)
        {
            UpdateDay();
        }
    }

    public void NotifyTimeChanged()
    {
        OnTimeChanged(Hour, Minutes);
    }

    public void NotifyDayEnd()
    {
        OnDayEnds();
    }
}