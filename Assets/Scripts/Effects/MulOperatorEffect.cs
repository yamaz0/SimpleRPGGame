using UnityEngine;

[System.Serializable]
public class MulOperatorEffect : OperatorEffect
{
    [SerializeField]
    [ModDropdown(nameof(Attributes))]
    private string attributeName;
    [SerializeField]
    private float value;
    public override float Calc(Character character)
    {
        Modificator modificator = character.Statistics.GetStatistic(attributeName);
        return modificator.Value * value;
    }
}
