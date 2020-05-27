using MyLittleDoctor.Player;
using MyLittleDoctor.Util;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class CameraController : IController
    {
        private Camera _camera;
        private readonly PlayerModel _player;

        public CameraController(PlayerModel player)
        {
            _player = player;
        }

        public void Initialize()
        {
            _camera = AssertExt.IsNotNull(Object.FindObjectOfType<Camera>());
        }

        public void Tick()
        {
            var playerPosition = _player.View.transform.position;
            _camera.transform.position = new Vector3(
                playerPosition.x,
                playerPosition.y,
                _camera.transform.position.z
            );
        }
    }
}