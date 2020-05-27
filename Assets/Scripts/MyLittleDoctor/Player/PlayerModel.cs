using MyLittleDoctor.Core;

namespace MyLittleDoctor.Player
{
    public class PlayerModel : Model<PlayerModel, PlayerView>
    {
        public readonly Inventory Inventory;

        public PlayerModel(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
}