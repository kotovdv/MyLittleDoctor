using MyLittleDoctor.Item;
using UnityEngine;
using UnityEngine.UI;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Text text;

        public void UpdateSlot(ItemBlueprint item, int quantity)
        {
            image.enabled = true;
            text.enabled = true;
            image.sprite = item.inventoryIcon;
            text.text = quantity.ToString();
        }
    }
}