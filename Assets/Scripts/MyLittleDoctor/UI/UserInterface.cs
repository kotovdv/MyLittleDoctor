using System;
using MyLittleDoctor.UI.Inventory;
using UnityEngine;

namespace MyLittleDoctor.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        public InventoryView InventoryView => _inventoryView;

        public void Awake()
        {
            _inventoryView.Hide();
        }
    }
}