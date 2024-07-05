using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillGuide : MonoBehaviour {
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName, commandAllows;

    public void Set(int skillId) {
        skillIcon.sprite = DataHolder.instance.skillDatas[skillId].icon;
        skillName.text = DataHolder.instance.skillDatas[skillId].name;
        //commandAllows.text = DataHolder.instance.skillDatas[skillId].command;
    }
}