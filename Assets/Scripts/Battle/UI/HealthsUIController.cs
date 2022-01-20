using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthsUIController : MonoBehaviour
{
    [SerializeField]
    private TextValueUI hp1;
    [SerializeField]
    private TextValueUI hp2;

    public void Init(Opponent op1, Opponent op2)
    {
        op1.Character.Statistics.Hp.OnValueChanged += hp1.SetTextValue;
        op2.Character.Statistics.Hp.OnValueChanged += hp2.SetTextValue;
        hp1.Init("Health: ", op1.Character.Statistics.Hp.Value.ToString());
        hp2.Init("Health: ", op2.Character.Statistics.Hp.Value.ToString());
    }
}
