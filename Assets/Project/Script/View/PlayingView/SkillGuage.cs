using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGuage : MonoBehaviour {

    [SerializeField] List<Image> masks = new List<Image>();
    [SerializeField] List<Image> fill = new List<Image>();
    [SerializeField] List<Image> whiteMasks = new List<Image>();
    [SerializeField] List<Image> whiteFill = new List<Image>();

    [SerializeField] float barWidth;

    public float mySkillPoint;
    // TODO:Demo
    public float enemySkillPoint;

    public void SetFill(float skillPoint) {

    }

    public void SetWhite(float chargingPoint) {

    }

}