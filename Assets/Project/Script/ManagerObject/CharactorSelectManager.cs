using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSelectManager : MonoBehaviour {
    public static CharactorSelectManager instance;

    public int currentSelectCharactorId = -1;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void DecideCharactor(int charaId) {
        currentSelectCharactorId = charaId;
    }
}