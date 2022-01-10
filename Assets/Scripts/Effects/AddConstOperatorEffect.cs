using UnityEngine;

[System.Serializable]
public class AddConstOperatorEffect : OperatorEffect
{
    [SerializeField]
    private float value;

    public AddConstOperatorEffect()
    {
    }

    public override float Calc(Character character)
    {
        return value;
    }
}
