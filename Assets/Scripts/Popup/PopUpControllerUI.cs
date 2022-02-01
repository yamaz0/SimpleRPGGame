using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControllerUI : MonoBehaviour
{
    [SerializeField]
    private PopUpUI endBattlePopUp;

    public void ShowEndBattlePopUp(string title, string desc)
    {
        endBattlePopUp.gameObject.SetActive(true);
        endBattlePopUp.Init(title, desc);
    }
}
