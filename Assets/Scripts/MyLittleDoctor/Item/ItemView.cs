using MyLittleDoctor.Player;
using UnityEngine;

namespace MyLittleDoctor.Item
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private long identifier;
        [SerializeField] private int _quantity;
        [SerializeField] private ItemBlueprint _itemBlueprint;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public long Identifier => identifier;
        public int Quantity => _quantity;
        public ItemBlueprint Item => _itemBlueprint;

        public void Initialize(ItemBlueprint item)
        {
            _itemBlueprint = item;
            _spriteRenderer.sprite = item.inventoryIcon;
            gameObject.name = item.itemName;
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }

        private void OnValidate()
        {
            if (_itemBlueprint != null)
                Initialize(_itemBlueprint);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<PlayerView>())
                return;

            Game.Instance.UserInterface.PickupSystem.Add(this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.GetComponent<PlayerView>())
                return;

            Game.Instance.UserInterface.PickupSystem.Remove(identifier);
        }
    }
}