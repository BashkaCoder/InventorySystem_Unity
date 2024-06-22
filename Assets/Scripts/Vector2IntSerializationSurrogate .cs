using System.Runtime.Serialization;
using UnityEngine;

namespace Inventory
{
    public class Vector2IntSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector2Int vector = (Vector2Int) obj;
            info.AddValue("x", vector.x);
            info.AddValue("y", vector.y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector2Int vector = (Vector2Int) obj;
            vector.x = info.GetInt32("x");
            vector.y = info.GetInt32("y");
            return vector;
        }
    }
}