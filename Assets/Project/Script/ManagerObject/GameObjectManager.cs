using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {

    public static GameObjectManager instance;
    [SerializeField] private GameObject packObject;
    public PackBehaviour currentPack;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void GameStart() {
        currentPack = Instantiate(packObject).GetComponent<PackBehaviour>();
        currentPack.Set();
        LifeManager.instance.Set();
    }


    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            ResetPack();
        }
    }

    public void ResetPack() {
        if (currentPack != null) {
            Destroy(currentPack.gameObject);
        }
        currentPack = Instantiate(packObject).GetComponent<PackBehaviour>();
        currentPack.Set();
    }

    public void ResetWorld() {
        if (currentPack != null) {
            Destroy(currentPack.gameObject);
        }
    }
}