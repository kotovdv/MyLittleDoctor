using MyLittleDoctor.Configuration;
using MyLittleDoctor.Item;
using UnityEngine;
using UnityEngine.UI;

namespace MyLittleDoctor.UI.Pickup
{
    public class PickupNotification : MonoBehaviour
    {
        [SerializeField] private Text text;
        private ControlsConfig _controlsConfig;

        public void Initialize(ControlsConfig controlsConfig)
        {
            _controlsConfig = controlsConfig;
        }

        public void Show(ItemBlueprint itemBlueprint, int quantity)
        {
            gameObject.SetActive(true);
            text.text = $"Press {_controlsConfig.PickupItem} to pick up {itemBlueprint.ItemName}({quantity})";
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}