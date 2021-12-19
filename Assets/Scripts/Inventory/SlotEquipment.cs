using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEquipment : Slot
{
    [SerializeField]
    private Equipement.EqType eqtype;

    public Equipement.EqType Eqtype { get => eqtype; set => eqtype = value; }
}
