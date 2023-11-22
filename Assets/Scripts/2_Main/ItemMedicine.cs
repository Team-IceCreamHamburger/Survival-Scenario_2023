using UnityEngine;

public class ItemMedicine : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }

    public ItemMedicine(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.MEDICINE;
    }
}