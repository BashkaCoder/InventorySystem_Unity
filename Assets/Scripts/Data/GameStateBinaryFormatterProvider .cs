using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Inventory
{
    public class GameStateBinaryFormatterProvider : IGameStateProvider, IGameStateSaver
    {
        private static readonly string FILEPATH = "save.bashka";

        public GameStateData GameState { get; private set; }

        public void LoadGameState()
        {
            if (File.Exists(FILEPATH))
            {
                using (FileStream fileStream = new FileStream(FILEPATH, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    SurrogateSelector ss = new SurrogateSelector();
                    Vector2IntSerializationSurrogate surrogate = new Vector2IntSerializationSurrogate();
                    ss.AddSurrogate(typeof(Vector2Int), new StreamingContext(StreamingContextStates.All), surrogate);
                    binaryFormatter.SurrogateSelector = ss;
                    GameState = (GameStateData)binaryFormatter.Deserialize(fileStream);
                }
            }
            else
            {
                GameState = InitFromSettings();
                SaveGameState();
            }
        }

        public void SaveGameState()
        {
            using (FileStream fileStream = new FileStream(FILEPATH, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SurrogateSelector ss = new SurrogateSelector();
                Vector2IntSerializationSurrogate surrogate = new Vector2IntSerializationSurrogate();
                ss.AddSurrogate(typeof(Vector2Int), new StreamingContext(StreamingContextStates.All), surrogate);
                binaryFormatter.SurrogateSelector = ss;
                binaryFormatter.Serialize(fileStream, GameState);
            }
        }

        private GameStateData InitFromSettings()
        {
            var gameState = new GameStateData
            {
                Inventories = new List<InventoryGridData>
                {
                    CreateTestInventory("Bashka"),
                    CreateTestInventory("NEBashka")
                }
            };

            return gameState;
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