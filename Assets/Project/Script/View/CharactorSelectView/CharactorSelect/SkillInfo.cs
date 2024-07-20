using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillInfo : MonoBehaviour {

    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private List<Image> commandAllows = new List<Image>();
    [SerializeField] private TextMeshProUGUI discription;

    public void Set(int skillId) {
        var currentSkillData = DataHolder.instance.skillDatas[skillId];
        skillIcon.sprite = currentSkillData.icon;
        skillName.text = currentSkillData.name;
        discription.text = currentSkillData.discription;

        foreach (var img in commandAllows) {
            img.enabled = false;
        }
        for (int i = 0; i < currentSkillData.command.Count; i++) {
            commandAllows[i].enabled = true;
            switch (currentSkillData.command[i]) {
                case 0:
                    commandAllows[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 1:
                    commandAllows[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case 2:
                    commandAllows[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case 3:
                    commandAllows[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                default:
                    break;
            }
        }
    }
}