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
    [SerializeField] List<Vector3> whiteMasksInitialPosition = new List<Vector3>();
    [SerializeField] List<Vector3> whiteFillsInitialPosition = new List<Vector3>();

    [SerializeField] List<Sprite> guageSprites = new List<Sprite>();
    [SerializeField] Image guageLabel;

    [SerializeField] float barWidth;

    private float currentSkillPoint;

    public void SetFirst() {
        for (int i = 0; i < 3; i++) {
            masksInitialPosition.Add(masks[i].rectTransform.localPosition);
            fillsInitialPosition.Add(fills[i].rectTransform.localPosition);
            whiteMasksInitialPosition.Add(whiteMasks[i].rectTransform.localPosition);
            whiteFillsInitialPosition.Add(whiteFills[i].rectTransform.localPosition);
        }
        SetFill(0);
        SetWhite(0);
    }

    public void SetFill(float skillPoint) {
        currentSkillPoint = skillPoint;
        if (skillPoint >= 300) {
            for (int i = 0; i < 3; i++) {
                masks[i].rectTransform.localPosition = masksInitialPosition[i];
                fills[i].rectTransform.localPosition = fillsInitialPosition[i];
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
        float sumPoint = currentSkillPoint + chargingPoint;
        Debug.Log(sumPoint);
        if (sumPoint >= 300) {
            for (int i = 0; i < 3; i++) {
                whiteMasks[i].rectTransform.localPosition = whiteMasksInitialPosition[i];
                whiteFills[i].rectTransform.localPosition = whiteFillsInitialPosition[i];
            }
        } else if (sumPoint >= 200) {
            float tmp = sumPoint - 200;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            whiteMasks[2].rectTransform.localPosition = whiteMasksInitialPosition[2] - differ;
            whiteFills[2].rectTransform.localPosition = whiteFillsInitialPosition[2] + differ;
            whiteMasks[1].rectTransform.localPosition = whiteMasksInitialPosition[1];
            whiteFills[1].rectTransform.localPosition = whiteFillsInitialPosition[1];
            whiteMasks[0].rectTransform.localPosition = whiteMasksInitialPosition[0];
            whiteFills[0].rectTransform.localPosition = whiteFillsInitialPosition[0];

        } else if (sumPoint >= 100) {
            float tmp = sumPoint - 100;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            whiteMasks[2].rectTransform.localPosition = whiteMasksInitialPosition[2] - new Vector3(barWidth, 0, 0);
            whiteFills[2].rectTransform.localPosition = whiteFillsInitialPosition[2] + new Vector3(barWidth, 0, 0);
            whiteMasks[1].rectTransform.localPosition = whiteMasksInitialPosition[1] - differ;
            whiteFills[1].rectTransform.localPosition = whiteFillsInitialPosition[1] + differ;
            whiteMasks[0].rectTransform.localPosition = whiteMasksInitialPosition[0];
            whiteFills[0].rectTransform.localPosition = whiteFillsInitialPosition[0];
        } else {
            float tmp = sumPoint;
            Vector3 differ = new Vector3((100 - tmp) / 100 * barWidth, 0, 0);
            whiteMasks[2].rectTransform.localPosition = whiteMasksInitialPosition[2] - new Vector3(barWidth, 0, 0);
            whiteFills[2].rectTransform.localPosition = whiteFillsInitialPosition[2] + new Vector3(barWidth, 0, 0);
            whiteMasks[1].rectTransform.localPosition = whiteMasksInitialPosition[1] - new Vector3(barWidth, 0, 0);
            whiteFills[1].rectTransform.localPosition = whiteFillsInitialPosition[1] + new Vector3(barWidth, 0, 0);
            whiteMasks[0].rectTransform.localPosition = whiteMasksInitialPosition[0] - differ;
            whiteFills[0].rectTransform.localPosition = whiteFillsInitialPosition[0] + differ;
        }
    }

}