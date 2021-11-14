using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : Singleton<TimeManager>
{

    private Days day = Days.Monday;

    public Days Day { get => day; private set => day = value; }
    public System.Action OnDayEnds = delegate{};

    public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

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

    public void NotifyDayEnd()
    {
        OnDayEnds();
    }
}