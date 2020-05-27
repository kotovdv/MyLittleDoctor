using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Player
{
    public class PlayerView : View<PlayerModel, PlayerView>
    {
        [SerializeField] private Rigidbody2D rbody2D;
        public Rigidbody2D Rigidbody2D => rbody2D;
    }
}