using MyLittleDoctor.Configuration;
using MyLittleDoctor.Player;
using MyLittleDoctor.UI.Inventory;
using MyLittleDoctor.UI.Pickup;
using UnityEngine;

namespace MyLittleDoctor.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private PickupNotification pickupNotification;
        private PickupSystem _pickupSystem;

        public InventoryView InventoryView => inventoryView;
        public PickupSystem PickupSystem => _pickupSystem;

        public void Initialize(PlayerModel player, GameConfig gameConfig)
        {
            inventoryView.Initialize(gameConfig.PlayerConfig.InventoryConfig);
            inventoryView.Subscribe(player.Inventory);
            inventoryView.Hide();

            pickupNotification.Initialize(gameConfig.ControlsConfig);
            _pickupSystem = new PickupSystem(player.Inventory, pickupNotification);
            pickupNotification.Hide();
        }
    }
}