using System.Collections.Generic;
using MyLittleDoctor.Controller;
using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor
{
    public class GameRunner : MonoBehaviour
    {
        private readonly IList<IController> _controllers = new List<IController>();

        public void Awake() {
            _controllers.Add(Game.Instance.TimeController);
            _controllers.Add(new PlayerController());
            _controllers.Add(new CameraController());
        }

        public void Start() {
            foreach (var controller in _controllers) {
                controller.Initialize();
            }
        }

        public void Update() {
            foreach (var controller in _controllers) {
                controller.Tick();
            }
        }
    }
}