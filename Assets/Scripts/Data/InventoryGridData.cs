using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class InventoryGridData
    {
        public string OwnerId;
        public List<InventorySlotData> Slots;
        public Vector2Int Size;

        public InventoryGridData() { }

        protected InventoryGridData(SerializationInfo info, StreamingContext context)
        {
            OwnerId = info.GetString("OwnerId");
            Slots = (List<InventorySlotData>)info.GetValue("Slots", typeof(List<InventorySlotData>));
            var sizeX = info.GetInt32("SizeX");
            var sizeY = info.GetInt32("SizeY");
            Size = new Vector2Int(sizeX, sizeY);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OwnerId", OwnerId);
            info.AddValue("Slots", Slots);
            info.AddValue("SizeX", Size.x);
            info.AddValue("SizeY", Size.y);
        }
    }
}