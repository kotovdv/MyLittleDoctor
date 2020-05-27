using MyLittleDoctor.Player;
using MyLittleDoctor.UI.Pickup;
using UnityEngine;

namespace MyLittleDoctor.Item
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private long identifier;
        [SerializeField] private int quantity;
        [SerializeField] private ItemBlueprint itemBlueprint;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private PickupSystem _pickupSystem;

        public long Identifier => identifier;
        public int Quantity => quantity;
        public ItemBlueprint Item => itemBlueprint;

        public void Initialize(PickupSystem pickupSystem)
        {
            _pickupSystem = pickupSystem;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnValidate()
        {
            if (itemBlueprint != null)
                ChangeBlueprint(itemBlueprint);
        }

        private void ChangeBlueprint(ItemBlueprint item)
        {
            itemBlueprint = item;
            spriteRenderer.sprite = item.InventoryIcon;
            gameObject.name = item.ItemName;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<PlayerView>())
                return;

            _pickupSystem.AddReachableItem(this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.GetComponent<PlayerView>())
                return;

            _pickupSystem.RemoveReachableItem(this);
        }
    }
}