using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class AttackEffect : TwoCharacterEffect
{
    [SerializeReference]
    private List<OperatorEffect> operators = new List<OperatorEffect>();
    [SerializeField]
    private float atak;

    public List<OperatorEffect> Operators { get => operators; set => operators = value; }
    public float CacheValue { get; set; }
    public float Atak { get => atak; set => atak = value; }

    public AttackEffect()
    {
        IsSingleUse = true;
    }

    public override void Execute(Character atacker, Character atacked)
    {
        foreach (var op in Operators)
        {
            CacheValue += op.Calc(atacker);
        }

        atacked.Statistics.Hp.AddValue(-CacheValue,false);
    }

    public override void Remove(Character atacker, Character atacked)
    {
        // atacked.Statistics.Hp.AddValue(CacheValue);
        Debug.LogError("Attack ");
    }


#if UNITY_EDITOR//to i wszystkie inne tego typu rzeczy przerzucić do osobnych klas typu EffectEditor, itemEditor itd
    public override void ViewInfo()
    {
        base.ViewInfo();
        UnityEditor.EditorGUILayout.LabelField($"Atak :{Atak}");
        UnityEditor.EditorGUILayout.LabelField($"Operators :");
        foreach (var op in Operators)
        {
            op.ViewInfo();
        }
    }

    public override void ViewFields()
    {
        base.ViewFields();
        Atak = UnityEditor.EditorGUILayout.FloatField("Atak", Atak);
        foreach (var op in Operators)
        {
            UnityEditor.EditorGUILayout.LabelField($"Op typ {op.GetType()}");
            op.ViewFields();
        }
        OperatorsButtons();
    }

    private void OperatorsButtons()
    {
        GUILayout.Label("Add Operator");
        GUILayout.BeginHorizontal();
        foreach (var t in System.Reflection.Assembly.GetAssembly(typeof(OperatorEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OperatorEffect))).ToList())
        {
            if (GUILayout.Button(t.ToString()))
            {
                Operators.Add(System.Activator.CreateInstance(t) as OperatorEffect);
            }
        }
        GUILayout.EndHorizontal();
    }
#endif
}