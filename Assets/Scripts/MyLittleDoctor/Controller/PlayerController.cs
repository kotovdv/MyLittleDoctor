using MyLittleDoctor.Core;
using MyLittleDoctor.Entity;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class PlayerController : IController
    {
        private Player _player;
        private Rigidbody2D _rigidbody2D;
        private const float Speed = 7F;

        public void Initialize() {
            var gameObject = GameObject.Find("Player");
            var entityView = gameObject.GetComponent<EntityView>();
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _player = new Player {View = entityView};
        }

        public void Tick() {
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");

            // var deltaX =  * Game.Instance.TimeController.DeltaGameTime;
            // var deltaY =  * Game.Instance.TimeController.DeltaGameTime;

            _rigidbody2D.velocity = new Vector2(horizontalAxis * Speed, verticalAxis * Speed);
        }
    }
}