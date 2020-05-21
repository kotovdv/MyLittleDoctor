using MyLittleDoctor.Core;
using MyLittleDoctor.Entity;
using MyLittleDoctor.UI;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class PlayerController : IController
    {
        private Player _player;
        private Rigidbody2D _rigidbody2D;
        private UserInterface _userInterface;
        private const float Speed = 7F;

        public void Initialize()
        {
            var gameObject = GameObject.Find("Player");
            _userInterface = GameObject.Find("UI").GetComponent<UserInterface>();
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        public void Tick()
        {
            HandleMovement();
            HandleUI();
        }

        private void HandleUI()
        {
            if (Input.GetKeyDown(KeyCode.I))
                _userInterface.InventoryView.InvertVisibility();
        }

        private void HandleMovement()
        {
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");

            _rigidbody2D.velocity = new Vector2(horizontalAxis, verticalAxis).normalized * Speed;
        }
    }
}