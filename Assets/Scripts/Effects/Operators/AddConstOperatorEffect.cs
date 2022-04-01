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
#if UNITY_EDITOR
    public override void ViewInfo()
    {
        UnityEditor.EditorGUILayout.LabelField($"Value to add :{value}");
    }

    public override void ViewFields()
    {
        value = UnityEditor.EditorGUILayout.FloatField("value", value);
    }
#endif
}
