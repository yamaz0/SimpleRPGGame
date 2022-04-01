using UnityEngine;

[System.Serializable]
public class StatisticOperatorEffect : OperatorEffect
{
    [SerializeField]
    [NameDropdown(nameof(CharacterStatistics))]
    private string statisticName;
    [SerializeField]
    private float value;
    public override float Calc(Character character)
    {
        Modificator modificator = character.Statistics.GetStatistic(statisticName);
        return modificator.Value * value;
    }
#if UNITY_EDITOR
    public override void ViewInfo()
    {
        UnityEditor.EditorGUILayout.LabelField($"Statistic Name :{statisticName}");
        UnityEditor.EditorGUILayout.LabelField($"Value to mul :{value}");
    }

    public override void ViewFields()
    {
        statisticName = UnityEditor.EditorGUILayout.TextField("Statistic Name", statisticName);
        value = UnityEditor.EditorGUILayout.FloatField("value", value);
    }
#endif
}
