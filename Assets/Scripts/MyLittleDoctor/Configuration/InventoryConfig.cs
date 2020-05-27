namespace MyLittleDoctor.Configuration
{
    public class InventoryConfig
    {
        public readonly int Rows;
        public readonly int Columns;

        public InventoryConfig(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}