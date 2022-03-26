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
    private Timer DoubleClickTimer { get; set; }
    private Timer TooltipTimer { get; set; }
    public bool IsDraggable { get => isDraggable; set => isDraggable = value; }
    public bool IsDragging { get; set; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsDraggable == true)
        {
            StartPos = transform.position;
            Index = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
            IsDragging = true;
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
            IsDragging = false;
        }
    }

    private void SingleClick(object o, System.EventArgs e)
    {
        DoubleClickTimer.Stop();
    }
    private void DoubleClick()
    {
        Controller.DoubleClick(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (DoubleClickTimer.Enabled == false)
        {
            DoubleClickTimer.Start();
        }
        else
        {
            DoubleClickTimer.Stop();
            DoubleClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public virtual void Init(Item item, IItemSlotUIController slotController)
    {
        Controller = slotController;
        DoubleClickTimer = new Timer();
        DoubleClickTimer.Interval = 400;
        DoubleClickTimer.Elapsed += SingleClick;
        TooltipTimer = new Timer();
        TooltipTimer.Interval = 400;
        TooltipTimer.Elapsed += ShowTooltip;
        ItemCache = item;
        if (ItemCache != null)
            icon.sprite = ItemCache.Icon;
        else
            icon.sprite = Resources.LoadAll<Sprite>("")[0];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsDragging == false)
        {
            TooltipTimer.Start();

        }
    }

    private void ShowTooltip(object o, System.EventArgs e)
    {
        PopUpManager.Instance.Tooltip.gameObject.SetActive(true);
        PopUpManager.Instance.Tooltip.Init(ItemCache, transform.position);
        TooltipTimer.Stop();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsDragging == false)
        {
            PopUpManager.Instance.Tooltip.gameObject.SetActive(false);
            TooltipTimer.Stop();
        }
    }
    private void OnDisable()
    {
        TooltipTimer.Stop();
        PopUpManager.Instance?.Tooltip.gameObject.SetActive(false);
    }
}