using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData {
    public string name;
    public List<int> command = new List<int>(); // up:0 down:1 left:2 right:3
    public string discription;
    public Sprite icon;
    public int level;
}