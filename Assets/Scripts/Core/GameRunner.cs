using System.Collections.Generic;
using Core.Controller;
using Core.View;
using Player;
using UnityEngine;

namespace Core
{
    public class GameRunner : MonoBehaviour
    {
        private readonly IList<IController> _controllers = new List<IController>();

        public void Awake() {
            var playerController = new PlayerController();
            var playerGO = GameObject.Find("Player");
            var entityView = playerGO.GetComponent<EntityView>();
            var player = new Player.Player();
            player.View = entityView;
            playerController.Player = player;

            _controllers.Add(playerController);
        }

        public void Update() {
            foreach (var controller in _controllers) {
                controller.Tick();
            }
        }
    }
}