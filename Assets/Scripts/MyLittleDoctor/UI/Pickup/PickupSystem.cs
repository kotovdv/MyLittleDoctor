using System.Collections.Generic;
using MyLittleDoctor.Item;
using MyLittleDoctor.Util;

namespace MyLittleDoctor.UI.Pickup
{
    public class PickupSystem
    {
        private readonly Player.Inventory _inventory;
        private readonly PickupNotification _notification;
        private readonly LinkedList<ItemView> _reachableItems = new LinkedList<ItemView>();

        public PickupSystem(
            Player.Inventory inventory,
            PickupNotification notification)
        {
            _inventory = inventory;
            _notification = notification;
        }

        public void PickUp()
        {
            if (_reachableItems.Count == 0)
                return;

            var item = _reachableItems.First.Value;

            var wasAdded = _inventory.AddItem(item.Item, item.Quantity);
            if (!wasAdded) return;

            _reachableItems.RemoveFirst();
            item.Destroy();
        }

        public void AddReachableItem(ItemView item)
        {
            _reachableItems.RemoveAll(i => i.Identifier == item.Identifier);
            _reachableItems.AddFirst(item);
            RefreshNotification();
        }

        public void RemoveReachableItem(ItemView item)
        {
            _reachableItems.RemoveAll(i => i.Identifier == item.Identifier);
            RefreshNotification();
        }

        private void RefreshNotification()
        {
            if (_reachableItems.Count == 0)
            {
                _notification.Hide();
            }
            else
            {
                var item = _reachableItems.First.Value;
                _notification.Show(item.Item, item.Quantity);
            }
        }
    }
}