using TMPro;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventorySLotView[] _slots;
        [SerializeField] private TMP_Text _textOwner;

        public string OwnerId
        {
            get => _textOwner.text;
            set => _textOwner.text = value;
        }

        public InventorySLotView GetInventorySlotView(int index)
        {
            return _slots[index];
        }

    }
}
