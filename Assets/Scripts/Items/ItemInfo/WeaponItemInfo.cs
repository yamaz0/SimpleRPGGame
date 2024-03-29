using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes { Sword, Axe, Club };
[System.Serializable]
public class WeaponItemInfo : ItemInfo
{
    private const string LABEL_ATTACK = "Attack: ";
    private const string LABEL_ATKSPEED = "AtkSpeed: ";
    [SerializeField]
    private WeaponTypes weaponType;
    [SerializeField]
    private int attack;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private bool twoHanded;

    public WeaponTypes WeaponType { get => weaponType; set => weaponType = value; }
    public int Attack { get => attack; set => attack = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public bool TwoHanded { get => twoHanded; set => twoHanded = value; }

    public WeaponItemInfo()
    {
        ItemType = ItemsManager.ItemType.EQUIPMENT;
    }

    public override Item CreateItem()
    {
        return new WeaponItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        Attack = ((WeaponItemInfo)item).Attack;
        AttackSpeed = ((WeaponItemInfo)item).AttackSpeed;
        TwoHanded = ((WeaponItemInfo)item).TwoHanded;
        WeaponType = ((WeaponItemInfo)item).WeaponType;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        Attack = UnityEditor.EditorGUILayout.IntField(LABEL_ATTACK, Attack);
        AttackSpeed = UnityEditor.EditorGUILayout.FloatField(LABEL_ATKSPEED, AttackSpeed);
        TwoHanded = UnityEditor.EditorGUILayout.Toggle(LABEL_ATKSPEED, TwoHanded);
        WeaponType = (WeaponTypes)UnityEditor.EditorGUILayout.EnumPopup(LABEL_ATKSPEED, WeaponType);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label(LABEL_ATTACK + Attack.ToString());
        GUILayout.Label(LABEL_ATKSPEED + AttackSpeed.ToString());
    }
#endif
}