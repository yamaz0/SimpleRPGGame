using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControllerUI : MonoBehaviour
{
    [SerializeField]
    private PopUpUI endBattlePopUp;

    public void ShowEndBattlePopUp(string title, string desc)
    {
        BattleManager.Instance.StopFight();
        endBattlePopUp.gameObject.SetActive(true);
        endBattlePopUp.Init(title, desc);
        endBattlePopUp.Button.onClick.AddListener(() => { BattleManager.Instance.BattleEnd(); });
    }
}
