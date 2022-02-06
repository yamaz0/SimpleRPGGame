using UnityEngine;

[System.Serializable]
public class MulOperatorEffect : OperatorEffect
{
    [SerializeField]
    [NameDropdown(nameof(Attributes))]
    private string attributeName;
    [SerializeField]
    private float value;
    public override float Calc(Character character)
    {
        Modificator modificator = character.Attributes.GetAttribute(attributeName);
        return modificator.Value * value;
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
