using MyLittleDoctor.Configuration;
using MyLittleDoctor.Player;
using MyLittleDoctor.UI;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class PlayerController : IController
    {
        private readonly PlayerModel _player;
        private readonly PlayerConfig _playerConfig;
        private readonly UserInterface _userInterface;
        private readonly ControlsConfig _controlsConfig;

        public PlayerController(
            PlayerModel player,
            GameConfig gameConfig,
            UserInterface userInterface)
        {
            _player = player;
            _playerConfig = gameConfig.PlayerConfig;
            _userInterface = userInterface;
            _controlsConfig = gameConfig.ControlsConfig;
        }

        public void Initialize() { }

        public void Tick()
        {
            HandleMovement();
            HandleUserInterface();
        }

        private void HandleMovement()
        {
            var verticalAxis = Input.GetAxis(_controlsConfig.VerticalMovementAxis);
            var horizontalAxis = Input.GetAxis(_controlsConfig.HorizontalMovementAxis);

            var direction = new Vector2(horizontalAxis, verticalAxis).normalized;
            _player.View.Rigidbody2D.velocity = direction * _playerConfig.Speed;
        }

        private void HandleUserInterface()
        {
            if (Input.GetKeyDown(_controlsConfig.Inventory))
                _userInterface.InventoryView.InvertVisibility();

            if (Input.GetKeyDown(_controlsConfig.PickupItem))
                _userInterface.PickupSystem.PickUp();
        }
    }
}