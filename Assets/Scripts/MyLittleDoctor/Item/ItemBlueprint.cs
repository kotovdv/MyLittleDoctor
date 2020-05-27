using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Item
{
    [CreateAssetMenu(menuName = "Blueprints/Item", order = 1)]
    public class ItemBlueprint : Blueprint
    {
        [SerializeField] private string itemName;
        [SerializeField] private ItemType type;
        [SerializeField] private Sprite inventoryIcon;
        [SerializeField] private GameObject prefabLink;

        public string ItemName => itemName;
        public ItemType Type => type;
        public Sprite InventoryIcon => inventoryIcon;
        public GameObject PrefabLink => prefabLink;
    }
}