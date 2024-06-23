using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] private PackBehaviour packObject;
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
            if(currentPack != null) {
                Destroy(currentPack.gameObject);
            }
            currentPack = Instantiate(packObject).GetComponent<PackBehaviour>();
            currentPack.Set();
        }
    }
}