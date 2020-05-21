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
                if (slotView != null)
                {
                    slotView.Reset();
                    _slots.Add(slotView);
                }
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


        private class SlotViewComparer : Comparer<InventorySlotView>
        {
            public override int Compare(InventorySlotView left, InventorySlotView right)
            {
                var leftPos = left.gameObject.transform.position;
                var rightPos = right.gameObject.transform.position;

                var xComparison = leftPos.x.CompareTo(rightPos.x);
                var yComparison = -leftPos.y.CompareTo(rightPos.y);

                return yComparison != 0
                    ? yComparison
                    : xComparison;
            }
        }
    }
}