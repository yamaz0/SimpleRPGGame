using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Image icon;
    public Item ItemCache { get; set; }
    public Vector3 StartPos { get; set; }
    public int Index = 0;

    private IItemSlotUIController Controller { get; set; }
    private Timer Timer { get; set; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartPos = transform.position;
        Index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        //tutaj jeszcze disable grid content albo cos
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Controller.OnDrop(eventData, this);
    }

    private void SingleClick(object o, System.EventArgs e)
    {
        Timer.Stop();
    }
    private void DoubleClick()
    {
        Controller.DoubleClick(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Timer.Enabled == false)
        {
            Timer.Start();
        }
        else
        {
            Timer.Stop();
            DoubleClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public virtual void Init(Item item, IItemSlotUIController slotController)
    {
        Controller = slotController;
        Timer = new Timer();
        Timer.Interval = 400;
        Timer.Elapsed += SingleClick;
        ItemCache = item;
        if (ItemCache != null)
            icon.sprite = ItemCache.Icon;
        else
            icon.sprite = Resources.LoadAll<Sprite>("")[0];
    }

}