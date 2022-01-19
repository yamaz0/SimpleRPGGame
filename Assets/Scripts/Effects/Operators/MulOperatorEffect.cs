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
        return modificator.BaseValue * value;
    }

    public override void ViewInfo()
    {
        UnityEditor.EditorGUILayout.LabelField($"attributeName :{attributeName}");
        UnityEditor.EditorGUILayout.LabelField($"Value to mul :{value}");
    }

    public override void ViewFields()
    {
        attributeName = UnityEditor.EditorGUILayout.TextField("attributeName", attributeName);
        value = UnityEditor.EditorGUILayout.FloatField("value", value);
    }
}
