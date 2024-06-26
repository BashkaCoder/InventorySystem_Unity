﻿using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;

        private const string Owner_1 = "Bashka";
        private const string Owner_2 = "NEBashka";
        private readonly string[] _itemIds = { "Яблоко", "Банан", "Киви" };

        private InventoryService _inventoryService;
        private ScreenController _screenController;
        private string _cachedOwnerId;

        private void Start()
        {
            //var gameStateProvider = new GameStatePlayerPrefsProvider();
            var gameStateProvider = new GameStateBinaryFormatterProvider();

            gameStateProvider.LoadGameState();

            _inventoryService = new InventoryService(gameStateProvider);

            var gameState = gameStateProvider.GameState;

            foreach (var inventoryData in gameState.Inventories)
            {
                _inventoryService.RegisterInventory(inventoryData);
            }

            _screenController = new ScreenController(_inventoryService, _screenView);
            _screenController.OpenInventory(Owner_1);
            _cachedOwnerId = Owner_1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                _screenController.OpenInventory(Owner_1);
                _cachedOwnerId = Owner_1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenController.OpenInventory(Owner_2);
                _cachedOwnerId = Owner_2;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);
                var result = _inventoryService.AddItemsToInventory(_cachedOwnerId, rItemId, rAmount);

                Debug.Log($"Item add: ${rItemId}. Amount: #{rAmount}");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);
                var result = _inventoryService.RemoveItems(_cachedOwnerId, rItemId, rAmount);

                Debug.Log($"Item remove: ${rItemId}. Trying to remove: #{result.ItemsToRemoveAmount}. Success: {result.Success}");
            }
        }
    }
}