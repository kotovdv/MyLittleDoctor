using MyLittleDoctor.Item;
using UnityEngine;

namespace MyLittleDoctor
{
    public class TestInventory : MonoBehaviour
    {
        [SerializeField] private ItemBlueprint _blueprint1;
        [SerializeField] private ItemBlueprint _blueprint2;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Game.Instance.Player.Inventory.AddItem(_blueprint1, 1);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                Game.Instance.Player.Inventory.AddItem(_blueprint2, 1);
            }
        }
    }
}