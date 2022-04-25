using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class TooltipUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text itemNameText;
    [SerializeField]
    private TMPro.TMP_Text descText;

    public TMP_Text ItemNameText { get => itemNameText; set => itemNameText = value; }
    public TMP_Text DescText { get => descText; set => descText = value; }
}
