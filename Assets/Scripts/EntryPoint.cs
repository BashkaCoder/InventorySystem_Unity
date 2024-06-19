using Inventory;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public InventoryGridView _view;

    private void Start()
    {
        //tmp
        var inventoryData = new InventoryGridData
        {
            Size = new Vector2Int(3, 4),
            OwnerId = "Bashka",
            Slots = new List<InventorySlotData>()
        };

        var size = inventoryData.Size;
        for (var i = 0; i < size.x; i++)
        {
            for (var j = 0; j < size.y; j++)
            {
                var index = i * size.y + j;
                inventoryData.Slots.Add(new InventorySlotData());
            }
        }

        //Fill slots

        var slotData = inventoryData.Slots[0];
        slotData.ItemId = "Банан";
        slotData.Amount = 3;
        //tmp

        var inventory = new InventoryGrid(inventoryData);

        _view.Setup(inventory);

    }
}