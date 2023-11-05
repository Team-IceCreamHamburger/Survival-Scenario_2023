using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerMain : MonoBehaviour {
    [Header("Main")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutter;

    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.shelterButton.onClick.AddListener(Shelter);
        this.rainGutter.onClick.AddListener(RainGutter);
        
        // TODO: Background Change
        if (GameInfo.Instance.CurrentDayNight == DayNightType.Day) {
            GameBackground.Instance.BackgroundChange("Background Day");
        } 
        else if (GameInfo.Instance.CurrentDayNight == DayNightType.Night) {
            GameBackground.Instance.BackgroundChange("Background Night");
        }
    }

    private void Awake() {
        Init();
    }

    private void Move() {
        if (CanMove()) {
            Player.Instance.CanvasChange("Canvas Move");
        }
    }

    private bool CanMove() {
        // Movable Conditions; All of Status over 25%, Search at least once more, Not injured.
        if (Player.Instance.Status[StatusType.STAMINA] > 25 && Player.Instance.Status[StatusType.BODY_HEAT] > 25 &&
            Player.Instance.Status[StatusType.CALORIES] > 25 && Player.Instance.Status[StatusType.HYDRATION] > 25) {    // Status OK
            if (GameInfo.Instance.IsSearched) {  // Searched
                if (!Player.Instance.Effect[EffectType.INJURE]) {   // Not Injured
                    // GOOD TO GO
                    return true;
                }
            }
        }

        return false;
    }
    
    private void Search() {
        if (CanSearch()) {
            Player.Instance.CanvasChange("Canvas Search");
        }
    }

    private bool CanSearch() {
        // Search Conditions; All of Status over 10%, Not injured, (Night) Need a 'Torch' item.
        if (Player.Instance.Status[StatusType.STAMINA] > 10 && Player.Instance.Status[StatusType.BODY_HEAT] > 10 &&
            Player.Instance.Status[StatusType.CALORIES] > 10 && Player.Instance.Status[StatusType.HYDRATION] > 10) {    // Status OK
            if (!Player.Instance.Effect[EffectType.INJURE]) {   // Not Injured
                if (GameInfo.Instance.CurrentDayNight == DayNightType.Night) {  // Night
                    if (Player.Instance.Inventory[ItemType.TORCH] >= 1) {    // Torch OK
                        // GOOD TO GO; Ani Scene
                        return true;
                    }
                    
                    return false;
                }

                return true;
            }
        }

        return false;
    }

    private void Fire() {
        if (CanFire()) {
            Player.Instance.CanvasChange("Canvas Fire");
            Player.Instance.CanvasOn("Canvas Info");
        }
    }

    private bool CanFire() {
        if (!GameInfo.Instance.IsFireInstalled) {
            // Fire Conditions; 점화도구 1개, 불쏘시개 3개, 나무 1개 -> 날씨 맑음: 70%, 날씨 비: 30%, 날씨 눈: 30% 
            if (Player.Instance.Inventory[ItemType.FIRE_TOOL] >= 1 && Player.Instance.Inventory[ItemType.KINDLING] >= 3 && 
                Player.Instance.Inventory[ItemType.WOOD] >= 1) {    // Material OK
                switch (GameInfo.Instance.CurrentWeather) {
                    case WeatherType.Sunny :
                        if (Random.Range(0, 10) > 3) {    // 70%
                            return true;
                        }

                        return false;
                
                    case WeatherType.Rain :
                        if (Random.Range(0, 10) > 7) {  // 30%
                            return true;
                        }
                    
                        return false;
                
                    case WeatherType.Snow :
                        if (Random.Range(0, 10) > 7) {  // 30%
                            return true;
                        }
                    
                        return false;
                }
            }
        }
        
        return true;
    }
    
    // Constructions
    private void Shelter() {
        Player.Instance.CanvasChange("Canvas Shelter");
        Player.Instance.CanvasOn("Canvas Info");
    }

    private void RainGutter() {
        Player.Instance.CanvasChange("Canvas RainGutter");
        Player.Instance.CanvasOn("Canvas Info");
    }
}