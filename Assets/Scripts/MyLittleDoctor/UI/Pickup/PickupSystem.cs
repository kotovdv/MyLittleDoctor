using System;
using System.Collections.Generic;
using MyLittleDoctor.Item;
using MyLittleDoctor.Util;

namespace MyLittleDoctor.UI.Pickup
{
    public class PickupSystem
    {
        private readonly Item.Inventory.Inventory _inventory;
        private readonly PickupNotification _notification;
        private readonly LinkedList<ItemView> _pickableItems = new LinkedList<ItemView>();

        public PickupSystem(
            Item.Inventory.Inventory inventory,
            PickupNotification notification)
        {
            _inventory = inventory;
            _notification = notification;
        }

        public void PickUp()
        {
            if (_pickableItems.Count == 0)
                return;
            var item = _pickableItems.First.Value;
            _inventory.AddItem(item.Item, item.Quantity);
            _pickableItems.RemoveFirst();
            item.Destroy();
        }

        public void Remove(long identifier)
        {
            _pickableItems.RemoveAll(i => i.Identifier == identifier);
            RefreshNotification();
        }

        public void Add(ItemView itemView)
        {
            _pickableItems.RemoveAll(i => i.Identifier == itemView.Identifier);
            _pickableItems.AddFirst(itemView);
            RefreshNotification();
        }

        private void RefreshNotification()
        {
            if (_pickableItems.Count == 0)
            {
                _notification.Hide();
            }
            else
            {
                var item = _pickableItems.First.Value;
                _notification.Show(item.Item, item.Quantity);
            }
        }
    }
}