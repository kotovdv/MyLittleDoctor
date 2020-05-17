using MyLittleDoctor.Core;
using MyLittleDoctor.Entity;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class PlayerController : IController
    {
        public Player Player;
        private const float Speed = 0.025F;

        public void Initialize() {
            var gameObject = GameObject.Find("Player");
            var entityView = gameObject.GetComponent<EntityView>();
            Player = new Player {View = entityView};
        }

        public void Tick() {
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");

            var deltaX = horizontalAxis * Speed;
            var deltaY = verticalAxis * Speed;

            Player.Position.x += deltaX;
            Player.Position.y += deltaY;
            Player.View.transform.position += new Vector3(deltaX, deltaY, 0);
        }
    }
}