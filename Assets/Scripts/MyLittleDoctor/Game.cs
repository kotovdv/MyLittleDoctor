using System.Collections.Generic;
using MyLittleDoctor.Configuration;
using MyLittleDoctor.Controller;
using MyLittleDoctor.Item;
using MyLittleDoctor.Item.Inventory;
using MyLittleDoctor.Player;
using MyLittleDoctor.UI;
using UnityEngine;

namespace MyLittleDoctor
{
    public class Game : MonoBehaviour
    {
        private Player.Player _player;
        private GameConfig _gameConfig;
        private UserInterface _userInterface;
        private ICollection<IController> _controllers;

        private void Awake()
        {
            InitializeGameConfiguration();
            InitializePlayer();
            InitializeUserInterface();
            InitializeControllers();
            InitializeLevel();
        }

        private void Start()
        {
            foreach (var controller in _controllers)
                controller.Initialize();
        }

        private void Update()
        {
            foreach (var controller in _controllers)
                controller.Tick();
        }

        private void InitializeGameConfiguration()
        {
            _gameConfig = new GameConfig(
                new PlayerConfig(7, new InventoryConfig(5, 4)),
                new ControlsConfig()
            );
        }

        private void InitializePlayer()
        {
            var playerView = FindObjectOfType<PlayerView>();
            var player = new Player.Player(new Inventory(
                _gameConfig.PlayerConfig.InventoryConfig.Rows,
                _gameConfig.PlayerConfig.InventoryConfig.Columns
            ));

            player.AttachView(playerView);
            playerView.AttachModel(player);

            _player = player;
        }

        private void InitializeUserInterface()
        {
            _userInterface = FindObjectOfType<UserInterface>();
            _userInterface.Initialize(_player, _gameConfig);
        }

        private void InitializeControllers()
        {
            _controllers = new List<IController>
            {
                new PlayerController(_player, _gameConfig, _userInterface),
                new CameraController(_player)
            };
        }

        private void InitializeLevel()
        {
            var itemViews = FindObjectsOfType<ItemView>();
            foreach (var itemView in itemViews)
                itemView.Initialize(_userInterface.PickupSystem);
        }
    }
}