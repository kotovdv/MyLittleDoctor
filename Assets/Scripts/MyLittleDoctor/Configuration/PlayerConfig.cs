namespace MyLittleDoctor.Configuration
{
    public class PlayerConfig
    {
        public readonly float Speed;
        public readonly InventoryConfig InventoryConfig;

        public PlayerConfig(float speed, InventoryConfig inventoryConfig)
        {
            Speed = speed;
            InventoryConfig = inventoryConfig;
        }
    }
}