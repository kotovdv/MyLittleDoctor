using MyLittleDoctor.Item;

namespace MyLittleDoctor.Player
{
    public class Inventory
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly InventorySlot[,] _slots;

        public event SlotChangedAction OnSlotChanged;

        public delegate void SlotChangedAction(int row, int column, ItemBlueprint item, int quantity);

        public Inventory(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _slots = new InventorySlot[rows, columns];
        }

        public bool AddItem(ItemBlueprint blueprint, int quantity, bool invokeEvents = true)
        {
            var position = FindSlotPosition(blueprint);
            if (!position.HasValue)
                return false;

            var row = position.Value.Item1;
            var column = position.Value.Item2;

            var slot = GetSlot(row, column);
            slot.Blueprint = blueprint;
            slot.Quantity += quantity;

            if (invokeEvents)
                OnSlotChanged?.Invoke(row, column, slot.Blueprint, slot.Quantity);

            return true;
        }

        private InventorySlot GetSlot(int row, int column)
        {
            var slot = _slots[row, column];
            if (slot == null)
            {
                slot = new InventorySlot();
                _slots[row, column] = slot;
            }

            return slot;
        }

        private (int, int)? FindSlotPosition(ItemBlueprint blueprint)
        {
            for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
            {
                var currentItem = _slots[i, j];
                if (currentItem == null || currentItem.Blueprint == blueprint)
                {
                    return (i, j);
                }
            }

            return null;
        }

        private class InventorySlot
        {
            public ItemBlueprint Blueprint;
            public int Quantity;
        }
    }
}