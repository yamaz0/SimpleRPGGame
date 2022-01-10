using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<SlotInventory> objects = new List<SlotInventory>(10);
    public SlotInventory slotTemplate;
    public Transform content;

    public List<SlotInventory> Objects { get => objects; set => objects = value; }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.I))
    //         Initialize();
    // }

    private void Start()
    {
        Objects = new List<SlotInventory>();
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh()
    {
        if (Objects.Count != 0)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                Destroy(Objects[i].gameObject);
            }
            Objects.Clear();
        }
        List<Item> items = Player.Instance.Character.InventoryController.Inventory.Items;

        foreach (var item in items)
        {
            CreateNewSlot(item);
        }
    }

    private void CreateNewSlot(Item item)
    {
        SlotInventory slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

}