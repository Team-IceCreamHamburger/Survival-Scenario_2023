using UnityEngine;

public class ItemFireTool : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "점화 도구";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.FIRE_TOOL;
    public override eventType EventType { get; } = eventType.NONE;

    private int durability = 1;
    

    public ItemFireTool(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}