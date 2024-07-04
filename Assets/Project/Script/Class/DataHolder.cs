using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour {
    public static DataHolder instance;

    public List<CharactorData> charactors = new List<CharactorData>();
    public List<SkillData> skillDatas = new List<SkillData>();

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}