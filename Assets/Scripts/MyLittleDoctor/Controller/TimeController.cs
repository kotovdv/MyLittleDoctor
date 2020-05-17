using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Controller
{
    public class TimeController : IController
    {
        public float DeltaGameTime { get; private set; }

        public void Initialize() { }

        public void Tick() {
            DeltaGameTime = Time.deltaTime;
        }
    }
}