using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {
    private Button _button;
    
    
    private void Init() {
        this._button = this.gameObject.GetComponent<Button>();
        this._button.onClick.AddListener(() => {
            // Game Loading...
            SceneManager.LoadScene("LoadingScene");
        
            // Has Previous Save Data?
            if (GameManager.Instance.GameFileCheck()) {  // True -> Load data
                GameManager.Instance.GameFileLoad();
            }
            else {  // False -> Create Data + Load Data
                GameManager.Instance.GameFileCreate();
                GameManager.Instance.GameFileLoad();
            }
        });
    }

    private void Awake() {
        Init();
    }
}