using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        private IList<InventorySlotView> _slots = new List<InventorySlotView>();

        private void Awake()
        {
            foreach (var slotView in GetComponentsInChildren<InventorySlotView>())
            {
                _slots.Add(slotView);
            }
        }

        public void InvertVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}