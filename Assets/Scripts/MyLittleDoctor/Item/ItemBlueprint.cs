using MyLittleDoctor.Core;
using UnityEngine;

namespace MyLittleDoctor.Item
{
    [CreateAssetMenu(menuName = "Blueprints/Item", order = 1)]
    public class ItemBlueprint : Blueprint
    {
        public string itemName;
        public ItemType type;
        public Sprite inventoryIcon;
        public GameObject prefabLink;
    }
}