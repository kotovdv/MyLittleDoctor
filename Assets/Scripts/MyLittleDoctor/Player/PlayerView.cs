using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Player
{
    public class PlayerView : View<Player, PlayerView>
    {
        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}