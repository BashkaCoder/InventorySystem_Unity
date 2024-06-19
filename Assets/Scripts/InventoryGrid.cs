using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryGrid : IReadOnlyInventoryGrid
    {
        public event Action<Vector2Int> SizeChanged;
        public event Action<string, int> ItemsAdded;
        public event Action<string, int> ItemsRemoved;

        public string OwnerId => _data.OwnerId;
        public Vector2Int Size
        {
            get => _data.Size;
            set 
            {
                if (_data.Size != value)
                {
                    _data.Size = value;
                    SizeChanged?.Invoke(Size);
                }    
            }
        }
        public InventoryGridData _data;
        private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new();

        public InventoryGrid(InventoryGridData data)
        {
            _data = data;

            var size = _data.Size;
            for (var i = 0; i < size.x; i++)
            {
                for (var j = 0; j < size.y; j++)
                {
                    var index = i * size.y + j;
                    var slotData = data.Slots[index];
                    var slot = new InventorySlot(slotData);
                    var position = new Vector2Int(i, j);

                    _slotsMap[position] = slot;
                }
            }
        }

        public int GetAmount(string itemId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyInventorySlot[,] GetSlots()
        {
            var array = new IReadOnlyInventorySlot[Size.x, Size.y];
            for (var i = 0; i < Size.x; i++)
            {
                for (var j = 0; j < Size.y; j++)
                {
                    var position = new Vector2Int(i, j);
                    array[position.x, position.y] = _slotsMap[position];
                }
            }

            return array;
        }

        public bool Has(string itemId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}