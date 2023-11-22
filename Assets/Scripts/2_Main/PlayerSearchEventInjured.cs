using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventInjured : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public PlayerSearchEventInjured(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InjuredEvent");
    }
}