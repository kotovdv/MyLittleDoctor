using MyLittleDoctor.Configuration;
using MyLittleDoctor.Item;
using UnityEngine;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject inventorySlotsContainer;
        [SerializeField] private GameObject inventorySlotViewPrefab;
        private InventorySlotView[,] _slots;

        public void Initialize(InventoryConfig inventoryConfig)
        {
            _slots = new InventorySlotView[inventoryConfig.Rows, inventoryConfig.Columns];

            for (var i = 0; i < inventoryConfig.Rows; i++)
            for (var j = 0; j < inventoryConfig.Columns; j++)
            {
                var slotView = Instantiate(
                    inventorySlotViewPrefab,
                    inventorySlotsContainer.transform
                );
                var inventorySlotView = slotView.GetComponent<InventorySlotView>();
                inventorySlotView.Reset();
                _slots[i, j] = inventorySlotView;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void InvertVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void Subscribe(Player.Inventory inventory)
        {
            inventory.OnSlotChanged += OnInventoryChanged;
        }

        private void OnInventoryChanged(int row, int column, ItemBlueprint item, int quantity)
        {
            var view = _slots[row, column];
            view.UpdateSlot(item, quantity);
        }
    }
}