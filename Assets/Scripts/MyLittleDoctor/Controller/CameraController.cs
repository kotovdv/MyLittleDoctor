using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class CameraController : IController
    {
        private GameObject _player;
        private Camera _camera;

        public void Initialize() {
            _player = GameObject.Find("Player");
            _camera = Object.FindObjectOfType<Camera>();
        }

        public void Tick() {
            var playerPosition = _player.transform.position;
            _camera.transform.position = new Vector3(playerPosition.x, playerPosition.y, _camera.transform.position.z);
        }
    }
}