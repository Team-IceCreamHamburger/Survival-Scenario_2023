using UnityEngine;

public class ItemHandAxe : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public int Durability { get; set; }
    public ItemType ItemType { get; set; }

    public ItemHandAxe(float weight = 0f, int count = 0, int durability = 5) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
        this.ItemType = ItemType.HAND_AXE;
    }
}