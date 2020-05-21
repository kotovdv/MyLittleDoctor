using MyLittleDoctor.Item;
using UnityEngine;
using UnityEngine.UI;

namespace MyLittleDoctor.UI.Inventory
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private Text itemName;
        [SerializeField] private Text itemCount;

        public void Reset()
        {
            SetState(false);
            itemName.text = "";
            itemCount.text = "";
            itemIcon.sprite = null;
        }

        public void UpdateSlot(ItemBlueprint item, int quantity)
        {
            SetState(true);
            itemName.text = item.itemName;
            itemCount.text = quantity.ToString();
            itemIcon.sprite = item.inventoryIcon;
        }


        private void SetState(bool state)
        {
            itemName.enabled = state;
            itemCount.enabled = state;
            itemIcon.enabled = state;
        }
    }
}