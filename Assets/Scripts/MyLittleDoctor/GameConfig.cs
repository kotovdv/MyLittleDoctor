namespace MyLittleDoctor
{
    public class GameConfig
    {
        public readonly PlayerConfig PlayerConfig;
        public readonly InventoryConfig InventoryConfig;

        public GameConfig(PlayerConfig playerConfig, InventoryConfig inventoryConfig)
        {
            PlayerConfig = playerConfig;
            InventoryConfig = inventoryConfig;
        }
    }
    
    public class PlayerConfig
    {
        public readonly float Speed;

        public PlayerConfig(float speed)
        {
            Speed = speed;
        }
    }
    
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