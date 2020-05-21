namespace MyLittleDoctor.Item.Inventory
{
    public class Inventory
    {
        public delegate void SlotChangedAction(int row, int column, ItemBlueprint item, int quantity);

        public event SlotChangedAction OnSlotChanged;

        private readonly int _rows;
        private readonly int _columns;
        private readonly InventorySlot[,] _slots;

        public Inventory(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _slots = new InventorySlot[rows, columns];
        }

        public void AddItem(ItemBlueprint blueprint, int quantity, bool invokeEvents = true)
        {
            var (row, column) = FindSlot(blueprint);

            var slot = _slots[row, column];

            if (slot == null)
            {
                slot = new InventorySlot {Blueprint = blueprint, Quantity = 0};
                _slots[row, column] = slot;
            }

            slot.Quantity += quantity;

            if (invokeEvents)
                OnSlotChanged?.Invoke(row, column, slot.Blueprint, slot.Quantity);
        }

        private (int, int) FindSlot(ItemBlueprint blueprint)
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    var currentItem = _slots[i, j];
                    if (currentItem == null || currentItem.Blueprint == blueprint)
                    {
                        return (i, j);
                    }
                }
            }

            //todo handle properly;
            return (-1, -1);
        }
    }
}