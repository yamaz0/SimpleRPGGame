using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUIController : MonoBehaviour
{
    [SerializeField]
    private List<AttributeUIController> attributeUIObjects;

    public List<AttributeUIController> AttributeUIObjects { get => attributeUIObjects; private set => attributeUIObjects = value; }
    [SerializeField]
    private TextValueUI maxHpText;
    [SerializeField]
    private TextValueUI damageText;
    [SerializeField]
    private TextValueUI attackSpeedText;
    [SerializeField]
    private TextValueUI defenceText;
    [SerializeField]
    private TextValueUI dodgeChanceText;
    [SerializeField]
    private TextValueUI blockChanceText;
    [SerializeField]
    private TextValueUI critChanceText;
    [SerializeField]
    private TextValueUI expText;
    [SerializeField]
    private TextValueUI twoHandedDamageBonusText;
    [SerializeField]
    private TextValueUI oneHandedDamageBonusText;
    [SerializeField]
    private TextValueUI dualWieldDamageBonusText;

    private void Start()
    {
        AttributeUIObjects.ForEach(x => x.Init());
        maxHpText.Init("maxHp", Player.Instance.Character.Statistics.MaxHp.Value.ToString());
        damageText.Init("damage", Player.Instance.Character.Statistics.Damage.Value.ToString());
        attackSpeedText.Init("attackSpeed", Player.Instance.Character.Statistics.AttackSpeed.Value.ToString());
        defenceText.Init("defence", Player.Instance.Character.Statistics.Defence.Value.ToString());
        dodgeChanceText.Init("dodgeChance", Player.Instance.Character.Statistics.DodgeChance.Value.ToString());
        blockChanceText.Init("blockChance", Player.Instance.Character.Statistics.BlockChance.Value.ToString());
        critChanceText.Init("critChance", Player.Instance.Character.Statistics.CritChance.Value.ToString());
        expText.Init("exp", Player.Instance.Character.Statistics.Exp.Value.ToString());
        twoHandedDamageBonusText.Init("twoHandedDamageBonus", Player.Instance.Character.Statistics.TwoHandedDamageBonus.Value.ToString());
        oneHandedDamageBonusText.Init("oneHandedDamageBonus", Player.Instance.Character.Statistics.OneHandedDamageBonus.Value.ToString());
        dualWieldDamageBonusText.Init("dualWieldDamageBonus", Player.Instance.Character.Statistics.DualWieldDamageBonus.Value.ToString());
    }

    private void OnEnable()
    {
        AttributeUIObjects.ForEach(x => x.AttachedEvents());
        Player.Instance.Character.Statistics.MaxHp.OnValueChanged += maxHpText.SetTextValue;
        Player.Instance.Character.Statistics.Damage.OnValueChanged += damageText.SetTextValue;
        Player.Instance.Character.Statistics.AttackSpeed.OnValueChanged += attackSpeedText.SetTextValue;
        Player.Instance.Character.Statistics.Defence.OnValueChanged += defenceText.SetTextValue;
        Player.Instance.Character.Statistics.DodgeChance.OnValueChanged += dodgeChanceText.SetTextValue;
        Player.Instance.Character.Statistics.BlockChance.OnValueChanged += blockChanceText.SetTextValue;
        Player.Instance.Character.Statistics.CritChance.OnValueChanged += critChanceText.SetTextValue;
        Player.Instance.Character.Statistics.Exp.OnValueChanged += expText.SetTextValue;
        Player.Instance.Character.Statistics.TwoHandedDamageBonus.OnValueChanged += twoHandedDamageBonusText.SetTextValue;
        Player.Instance.Character.Statistics.OneHandedDamageBonus.OnValueChanged += oneHandedDamageBonusText.SetTextValue;
        Player.Instance.Character.Statistics.DualWieldDamageBonus.OnValueChanged += dualWieldDamageBonusText.SetTextValue;
    }

    private void OnDisable()
    {
        AttributeUIObjects.ForEach(x => x.DetachEvents());
        Player.Instance.Character.Statistics.MaxHp.OnValueChanged -= maxHpText.SetTextValue;
        Player.Instance.Character.Statistics.Damage.OnValueChanged -= damageText.SetTextValue;
        Player.Instance.Character.Statistics.AttackSpeed.OnValueChanged -= attackSpeedText.SetTextValue;
        Player.Instance.Character.Statistics.Defence.OnValueChanged -= defenceText.SetTextValue;
        Player.Instance.Character.Statistics.DodgeChance.OnValueChanged -= dodgeChanceText.SetTextValue;
        Player.Instance.Character.Statistics.BlockChance.OnValueChanged -= blockChanceText.SetTextValue;
        Player.Instance.Character.Statistics.CritChance.OnValueChanged -= critChanceText.SetTextValue;
        Player.Instance.Character.Statistics.Exp.OnValueChanged -= expText.SetTextValue;
        Player.Instance.Character.Statistics.TwoHandedDamageBonus.OnValueChanged -= twoHandedDamageBonusText.SetTextValue;
        Player.Instance.Character.Statistics.OneHandedDamageBonus.OnValueChanged -= oneHandedDamageBonusText.SetTextValue;
        Player.Instance.Character.Statistics.DualWieldDamageBonus.OnValueChanged -= dualWieldDamageBonusText.SetTextValue;
    }
}
