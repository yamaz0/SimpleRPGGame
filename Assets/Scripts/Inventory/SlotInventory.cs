using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInventory : Slot, IBeginDragHandler, IDragHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 StartPos { get; set; }
    private int Index = 0;

    private Timer Timer { get; set; }
    private void Start()
    {
        Timer = new Timer();
        Timer.Interval = 400;
        Timer.Elapsed += SingleClick;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start");
        StartPos = transform.position;
        Index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        //tutaj jeszcze disable grid content albo cos
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("end");
        List<RaycastResult> res = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, res);
        for (int i = 0; i < res.Count; i++)
        {
            SlotEquipment slot = res[i].gameObject.GetComponent<SlotEquipment>();
            if (slot != null)
            {
                IEquipable tmp = ItemCache as IEquipable;
                if (tmp != null)
                {
                    tmp.Equip();
                    break;
                }
                //else nie mozna ubrac komunikat
            }
        }
        transform.SetSiblingIndex(Index);
        transform.position = StartPos;
        // gameObject.SetActive(false);
        // gameObject.SetActive(true);
    }

    private void SingleClick(object o, System.EventArgs e)
    {
        Timer.Stop();
    }
    private void DoubleClick()
    {
        IUseable useable = ItemCache as IUseable;
        if (useable != null)
            useable.Use();
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
}
