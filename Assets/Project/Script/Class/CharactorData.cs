using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharactorData {
    public int id;
    public string name;
    public string story;
    public List<int> SkillIds = new List<int>();
    public Sprite selectingImage;
    public string lockedMessage;
}