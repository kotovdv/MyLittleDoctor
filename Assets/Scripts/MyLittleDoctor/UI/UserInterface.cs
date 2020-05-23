using MyLittleDoctor.UI.Inventory;
using MyLittleDoctor.UI.Pickup;
using UnityEngine;

namespace MyLittleDoctor.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private PickupNotification _pickupNotification;
        private PickupSystem _pickupSystem;

        public InventoryView InventoryView => _inventoryView;
        public PickupSystem PickupSystem => _pickupSystem;

        public void Initialize(Player.Player player)
        {
            _inventoryView.Initialize();
            _inventoryView.Subscribe(player.Inventory);
            _pickupSystem = new PickupSystem(player.Inventory, _pickupNotification);
        }
    }
}