using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private bool isDraggable = true;
    public Item ItemCache { get; set; }
    public Vector3 StartPos { get; set; }
    public int Index = 0;

    private IItemSlotUIController Controller { get; set; }
    private Timer Timer { get; set; }
    public bool IsDraggable { get => isDraggable; set => isDraggable = value; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsDraggable == true)
        {
            StartPos = transform.position;
            Index = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
        }
        //tutaj jeszcze disable grid content albo cos
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (IsDraggable == true)
        {
            transform.position = Mouse.current.position.ReadValue();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (IsDraggable == true)
        {
            Controller.OnDrop(eventData, this);
        }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        PopUpManager.Instance.Tooltip.gameObject.SetActive(true);
        PopUpManager.Instance.Tooltip.Init(ItemCache, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PopUpManager.Instance.Tooltip.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        PopUpManager.Instance.Tooltip.gameObject.SetActive(false);
    }
}