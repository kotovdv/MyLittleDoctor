using UnityEngine;
using UnityEngine.UIElements;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private GameObject iconGameObject;
        private Image _iconImage;

        public void Awake()
        {
            _iconImage = iconGameObject.GetComponent<Image>();
        }
    }
}