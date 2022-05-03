using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationWindowController : MonoBehaviour
{
    [SerializeField]
    private NotificationUI template;
    [SerializeField]
    private Transform content;

    public void ShowNotification(string text, Sprite icon = null)
    {
        NotificationUI newNotification = Instantiate(template, content);
        newNotification.Init(text, icon);
        newNotification.gameObject.SetActive(true);
    }
}
