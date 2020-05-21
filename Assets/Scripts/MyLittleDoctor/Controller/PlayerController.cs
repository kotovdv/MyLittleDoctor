using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class PlayerController : IController
    {
        private float _speed;

        public void Initialize()
        {
            _speed = Game.Instance.GameConfig.PlayerConfig.Speed;
        }

        public void Tick()
        {
            HandleMovement();
            HandleUI();
        }

        private void HandleUI()
        {
            if (Input.GetKeyDown(KeyCode.I))
                Game.Instance.UserInterface.InventoryView.InvertVisibility();
        }

        private void HandleMovement()
        {
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");
            Game.Instance.Player.View.Rigidbody2D.velocity =
                new Vector2(horizontalAxis, verticalAxis).normalized * _speed;
        }
    }
}