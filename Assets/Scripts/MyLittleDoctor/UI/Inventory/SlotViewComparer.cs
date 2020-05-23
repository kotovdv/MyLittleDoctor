using System.Collections.Generic;

namespace MyLittleDoctor.UI.Inventory
{
    public class SlotViewComparer : Comparer<InventorySlotView>
    {
        public override int Compare(InventorySlotView left, InventorySlotView right)
        {
            var leftPos = left.gameObject.transform.position;
            var rightPos = right.gameObject.transform.position;

            var xComparison = leftPos.x.CompareTo(rightPos.x);
            var yComparison = -leftPos.y.CompareTo(rightPos.y);

            return yComparison != 0
                ? yComparison
                : xComparison;
        }
    }
}