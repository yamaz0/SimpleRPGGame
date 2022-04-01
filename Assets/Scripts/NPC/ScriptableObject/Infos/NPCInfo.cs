using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private RuntimeAnimatorController animatorController;
    public Sprite Icon { get => icon; set => icon = value; }
    public RuntimeAnimatorController AnimatorController { get => animatorController; set => animatorController = value; }

    public virtual NPCBase CreateNpc()
    {
        return null;
    }
}