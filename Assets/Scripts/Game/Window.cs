using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private bool canPlayerMove;

    private void OnEnable()
    {
        if (canPlayerMove == false)
        {
            GameManager.Instance.SetPlayerCanMove(false);
        }
    }

    private void OnDisable()
    {
        if (canPlayerMove == false)
        {
            GameManager.Instance.SetPlayerCanMove(true);
        }
    }
}
