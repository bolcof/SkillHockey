using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
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
}