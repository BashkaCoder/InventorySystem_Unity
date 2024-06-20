using Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        public InventoryGridView _view;
        private InventoryService _inventoryService;

        private void Start()
        {
            //tmp

            _inventoryService = new InventoryService();

            var ownerId = "Bashka";
            var inventoryData = CreateTestInventory(ownerId);
            var inventory = _inventoryService.RegisterInventory(inventoryData);
            
            _view.Setup(inventory);

            var addedResult = _inventoryService.AddItemsToInventory(ownerId, new Vector2Int(1, 1),  "apple", 30);
            Debug.Log($"Items added. ItemId: apple, amount to add 30, amount added: {addedResult.ItemsAddedAmount}");

            addedResult = _inventoryService.AddItemsToInventory(ownerId, "кирпич", 112);
            Debug.Log($"Items added. ItemId: кирпич, amount to add 112, amount added: {addedResult.ItemsAddedAmount}");

            addedResult = _inventoryService.AddItemsToInventory(ownerId, "letter", 10);
            Debug.Log($"Items added. ItemId: letter, amount to add 10, amount added: {addedResult.ItemsAddedAmount}");

            _view.Print();

            var removedResult = _inventoryService.RemoveItems(ownerId, "apple", 13);
            Debug.Log($"Items removed. ItemId: apple, amount to remove: 13, Success: {removedResult.Success}");

            _view.Print();

            removedResult = _inventoryService.RemoveItems(ownerId, "apple", 18);
            Debug.Log($"Items removed. ItemId: apple, amount to remove: 18, Success: {removedResult.Success}");

            _view.Print();

            //tmp
        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4);
            var createdInventorySlots = new List<InventorySlotData>();
            var length = size.x * size.y;
            for (var i = 0; i < length; i++)
            {
                createdInventorySlots.Add(new InventorySlotData());
            }

            var createdInventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Slots = createdInventorySlots
            };

            return createdInventoryData;
        }

    }
}