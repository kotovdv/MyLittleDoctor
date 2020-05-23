using System.Collections.Generic;
using MyLittleDoctor.Item;
using UnityEngine;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        private readonly List<InventorySlotView> _slots = new List<InventorySlotView>();

        public void Initialize()
        {
            _slots.Clear();

            foreach (var slotView in GetComponentsInChildren<InventorySlotView>())
            {
                if (slotView == null) continue;
                
                slotView.Reset();
                _slots.Add(slotView);
            }

            _slots.Sort(new SlotViewComparer());
        }

        public void Subscribe(Item.Inventory.Inventory inventory)
        {
            inventory.OnSlotChanged += OnInventoryChanged;
        }

        public void InvertVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private void OnInventoryChanged(int row, int column, ItemBlueprint item, int quantity)
        {
            int index = row * Game.Instance.GameConfig.InventoryConfig.Rows + column;
            var view = _slots[index];
            view.UpdateSlot(item, quantity);
        }
    }
}