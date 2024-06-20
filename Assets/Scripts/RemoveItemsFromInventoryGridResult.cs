namespace Inventory
{
    public readonly struct RemoveItemsFromInventoryGridResult
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Success;

        public RemoveItemsFromInventoryGridResult(string inventoryOwnerId, int itemsToRemove, bool success)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToRemoveAmount = itemsToRemove;
            Success = success;
        }
    }
}
