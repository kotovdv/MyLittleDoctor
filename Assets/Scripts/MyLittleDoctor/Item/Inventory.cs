namespace MyLittleDoctor.Item
{
    public class Inventory
    {
        private const int Rows = 5;
        private const int Columns = 4;

        private readonly Item[,] _items = new Item[Rows, Columns];

        public void AddItem(ItemBlueprint blueprint, int quantity)
        {
            var (row, column) = FindSlot(blueprint);
            ref var item = ref _items[row, column];

            if (item == null)
            {
                item = new Item {Blueprint = blueprint, Quantity = 0};
                _items[row, column] = item;
            }

            item.Quantity += quantity;
        }

        private (int, int) FindSlot(ItemBlueprint blueprint)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var currentItem = _items[i, j];
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