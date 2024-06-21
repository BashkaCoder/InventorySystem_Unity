namespace Inventory
{
    public class InventorySlotController
    {
        private readonly InventorySLotView _view;

        public InventorySlotController(IReadOnlyInventorySlot slot, InventorySLotView view)
        {
            _view = view;

            slot.ItemIdChanged += OnSlotItemIdChanged;
            slot.ItemAmountChanged += OnSlotItemAmountChanged;
        
            view.Title = slot.ItemId;
            view.Amount = slot.Amount;
        }

        private void OnSlotItemAmountChanged(int newItemAmount)
        {
            _view.Amount = newItemAmount;
        }

        private void OnSlotItemIdChanged(string newItemId)
        {
            _view.Title = newItemId;
        }
    }
}