using System;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class SerializableVector2Int
    {
        public int x;
        public int y;

        public SerializableVector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public SerializableVector2Int(Vector2Int vector)
        {
            x = vector.x;
            y = vector.y;
        }

        public Vector2Int ToVector2Int()
        {
            return new Vector2Int(x, y);
        }
    }
}