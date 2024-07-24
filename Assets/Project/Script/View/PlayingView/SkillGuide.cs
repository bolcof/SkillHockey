using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillGuide : MonoBehaviour {
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName;

    [SerializeField] private List<Sprite> allowSprites = new List<Sprite>();
    [SerializeField] private List<Image> commandAllows = new List<Image>();

    public void Set(int skillId) {
        var currentSkillData = DataHolder.instance.skillDatas[skillId];
        skillIcon.sprite = currentSkillData.icon;
        skillName.text = currentSkillData.name;
        foreach (var a in commandAllows) {
            a.enabled = false;
        }
        for (int i = 0; i < currentSkillData.command.Count; i++) {
            commandAllows[i].enabled = true;
            commandAllows[i].sprite = allowSprites[currentSkillData.command[i]];
        }
    }
}