using MyLittleDoctor.Core;
using MyLittleDoctor.Item.Inventory;

namespace MyLittleDoctor.Player
{
    public class Player : Model<Player, PlayerView>
    {
        public readonly Inventory Inventory;

        public Player(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
}