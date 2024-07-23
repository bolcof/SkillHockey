using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGuage : MonoBehaviour {

    [SerializeField] List<Image> masks = new List<Image>();
    [SerializeField] List<Image> fills = new List<Image>();
    [SerializeField] List<Vector3> masksInitialPosition = new List<Vector3>();
    [SerializeField] List<Vector3> fillsInitialPosition = new List<Vector3>();

    [SerializeField] List<Image> whiteMasks = new List<Image>();
    [SerializeField] List<Image> whiteFills = new List<Image>();

    [SerializeField] List<Sprite> guageSprites = new List<Sprite>();
    [SerializeField] Image guageLabel;

    [SerializeField] float barWidth;

    public float skillPoint;
    public float chargingPoint;

    public bool isDebug;
    public float testSkillPoint = 150;
    public float testChargingPoint;

    public void Set() {
        for (int i = 0; i < 3; i++) {
            masks[i].rectTransform.position = masks[2].rectTransform.localPosition + new Vector3(-barWidth, 0, 0);
            fills[i].rectTransform.position = new Vector3(barWidth, 0, 0);
        }
        testSkillPoint = 150;
        SetFill(testSkillPoint);
    }

    private void Start() {
        for (int i = 0; i < 3; i++) {
            masksInitialPosition.Add(masks[i].rectTransform.localPosition);
            fillsInitialPosition.Add(fills[i].rectTransform.localPosition);
        }
        //Set();
    }

    private void Update() {
        SetFill(testSkillPoint);
        //SetWhite(testChargingPoint);
    }

    public void SetFill(float skillPoint) {
        if (skillPoint >= 300) {
            for (int i = 0; i < 3; i++) {
                masks[i].rectTransform.localPosition = masks[i].rectTransform.localPosition;
                fills[i].rectTransform.localPosition = new Vector3(0, 0, 0);
            }
            guageLabel.sprite = guageSprites[3];
        } else if (skillPoint >= 200) {
            float tmp = skillPoint - 200;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            masks[2].rectTransform.localPosition = masksInitialPosition[2] - differ;
            fills[2].rectTransform.localPosition = fillsInitialPosition[2] + differ;
            masks[1].rectTransform.localPosition = masksInitialPosition[1];
            fills[1].rectTransform.localPosition = fillsInitialPosition[1];
            masks[0].rectTransform.localPosition = masksInitialPosition[0];
            fills[0].rectTransform.localPosition = fillsInitialPosition[0];
            guageLabel.sprite = guageSprites[2];

        } else if (skillPoint >= 100) {
            float tmp = skillPoint - 100;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            masks[2].rectTransform.localPosition = masksInitialPosition[2] - new Vector3(barWidth, 0, 0);
            fills[2].rectTransform.localPosition = fillsInitialPosition[2] + new Vector3(barWidth, 0, 0);
            masks[1].rectTransform.localPosition = masksInitialPosition[1] - differ;
            fills[1].rectTransform.localPosition = fillsInitialPosition[1] + differ;
            masks[0].rectTransform.localPosition = masksInitialPosition[0];
            fills[0].rectTransform.localPosition = fillsInitialPosition[0];
            guageLabel.sprite = guageSprites[1];
        } else {
            float tmp = skillPoint;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            masks[2].rectTransform.localPosition = masksInitialPosition[2] - new Vector3(barWidth, 0, 0);
            fills[2].rectTransform.localPosition = fillsInitialPosition[2] + new Vector3(barWidth, 0, 0);
            masks[1].rectTransform.localPosition = masksInitialPosition[1] - new Vector3(barWidth, 0, 0);
            fills[1].rectTransform.localPosition = fillsInitialPosition[1] + new Vector3(barWidth, 0, 0);
            masks[0].rectTransform.localPosition = masksInitialPosition[0] - differ;
            fills[0].rectTransform.localPosition = fillsInitialPosition[0] + differ;
            guageLabel.sprite = guageSprites[0];
        }
    }

    public void SetWhite(float chargingPoint) {
        if (isDebug) {
            Debug.Log("mask :" + masks[2].rectTransform.localPosition.ToString());
            Debug.Log("fill :" + fills[2].rectTransform.localPosition.ToString());
        }
    }

}