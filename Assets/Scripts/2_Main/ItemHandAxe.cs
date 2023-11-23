using UnityEngine;

public class itemHandAxe : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public int Durability { get; set; }
    public itemType ItemType { get; set; }


    public itemHandAxe(float weight = 0f, int count = 0, int durability = 5, bool isAcquirable = false) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
        this.IsAcquirable = isAcquirable;
        this.ItemType = itemType.HAND_AXE;
    }
    
    public void ItemFarming() { // TODO: 탐색하기 파밍 이벤트 결과 (수집 불가 아이템)
    }
}