using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificatorsManager : Singleton<ModificatorsManager>
{
    [SerializeField]
    private Dictionary<string, Modificator> dictModyficators = new Dictionary<string, Modificator>();
    [SerializeField]
    private ModificatorsSO modificatorsSO;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Text textnaem;
    [SerializeField]
    private Text textvalue;
    [SerializeField]
    [ModDropdown]
    private string mod;

    public Dictionary<string, Modificator> DictModyficators { get => dictModyficators; private set => dictModyficators = value; }
    public string Mod { get => mod; set => mod = value; }

    private void Update()
    {
        textnaem.text = Mod;
        textvalue.text = DictModyficators[Mod].Value.ToString();
        if (Input.GetKeyDown(KeyCode.M))
        {
            DictModyficators[Mod].AddValue(1);
        }
    }

    protected override void Initialize()
    {
        DictModyficators.Clear();
        foreach (ModificatorInfo info in modificatorsSO.ModyficatorsInfo)
        {
            Modificator propertyInfo = ModificatorsSO.GetModifier(player.Character, info);
            DictModyficators.Add(info.PropertyName, propertyInfo);
        }
    }
}
