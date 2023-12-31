using UnityEngine;

public class ItemFireTool : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "점화 도구";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.FIRE_TOOL;
    public eventType EventType { get; } = eventType.NONE;

    private int durability = 1;
    

    public ItemFireTool(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse(int value) {
        return true;
    }
    
    public int ItemAcquire() {
        return 0;
    }
}