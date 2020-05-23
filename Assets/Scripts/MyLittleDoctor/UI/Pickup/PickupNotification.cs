using MyLittleDoctor.Item;
using UnityEngine;
using UnityEngine.UI;

namespace MyLittleDoctor.UI.Pickup
{
    public class PickupNotification : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void Show(ItemBlueprint itemBlueprint, int quantity)
        {
            gameObject.SetActive(true);
            _text.text = $"Press E to pick up {itemBlueprint.itemName}({quantity})";
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}