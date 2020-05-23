using MyLittleDoctor.Controller;
using MyLittleDoctor.Item.Inventory;
using MyLittleDoctor.Player;
using MyLittleDoctor.UI;
using UnityEngine;

namespace MyLittleDoctor
{
    public class Game
    {
        public static readonly Game Instance = new Game();

        public Player.Player Player { get; private set; }
        public GameConfig GameConfig { get; private set; }
        public UserInterface UserInterface { get; private set; }

        public readonly TimeController TimeController = new TimeController();

        public void Initialize()
        {
            InitializeGameConfiguration();
            InitializePlayer();
            InitializeUserInterface();
        }

        private void InitializeGameConfiguration()
        {
            var inventoryConfig = new InventoryConfig(5, 4);
            var playerConfig = new PlayerConfig(7);
            GameConfig = new GameConfig(playerConfig, inventoryConfig);
        }

        private void InitializePlayer()
        {
            var playerView = Object.FindObjectOfType<PlayerView>();
            var player = new Player.Player(new Inventory(
                GameConfig.InventoryConfig.Rows,
                GameConfig.InventoryConfig.Columns
            ));
            player.AttachView(playerView);
            playerView.AttachModel(player);

            Player = player;
        }

        private void InitializeUserInterface()
        {
            UserInterface = Object.FindObjectOfType<UserInterface>();
            UserInterface.Initialize(Player);
        }
    }
}