using UnityEngine;

namespace MyLittleDoctor.Configuration
{
    public class ControlsConfig
    {
        public KeyCode Inventory { get; } = KeyCode.I;
        public KeyCode PickupItem { get; } = KeyCode.E;
        public string VerticalMovementAxis { get; } = "Vertical";
        public string HorizontalMovementAxis { get; } = "Horizontal";
    }
}