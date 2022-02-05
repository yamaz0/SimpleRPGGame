using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class NPCInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private UnityEditor.Animations.AnimatorController animator;
    public Sprite Icon { get => icon; set => icon = value; }
    public AnimatorController AnimatorController { get => animator; set => animator = value; }

    public virtual NPCBase CreateNpc()
    {
        return null;
    }
}