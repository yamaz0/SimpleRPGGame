using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<Slot> objects = new List<Slot>(10);
    public Slot slotTemplate;
    public Transform content;

    public List<Slot> Objects { get => objects; set => objects = value; }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.I))
    //         Initialize();
    // }

    private void Start()
    {
        Objects = new List<Slot>();
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh(int nothing = 0)
    {
        InventoryItemSlotUIController ctrl = new InventoryItemSlotUIController();
        List<Item> items = Player.Instance.Character.InventoryController.Inventory.Items;

        if (Objects.Count != 0)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                Destroy(Objects[i].gameObject);
            }
            Objects.Clear();
        }

        foreach (var item in items)
        {
            CreateNewSlot(item, ctrl);
        }
    }

    private void CreateNewSlot(Item item, InventoryItemSlotUIController controller)
    {
        Slot slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item, controller);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

}