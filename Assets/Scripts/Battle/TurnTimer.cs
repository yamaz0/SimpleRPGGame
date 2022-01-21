using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer
{
    public int DurationTurnTime { get; set; }
    public int RemainingTurnTime { get; set; }
    public event System.Action<int> OnTimeChanged = delegate { };

    public TurnTimer(int time)
    {
        DurationTurnTime = time;
        Reset();
    }

    public void Reset()
    {
        RemainingTurnTime = DurationTurnTime;
    }

    private void Tick()
    {
        RemainingTurnTime--;
        OnTimeChanged(RemainingTurnTime);
    }

    public bool CheckTime()
    {
        if (RemainingTurnTime < 1)
            return true;
        Tick();
        return false;
    }
}