using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CutIn : MonoBehaviour {
    [SerializeField] Image background;
    [SerializeField] Sprite frameP1L1, frameP1L2, frameP2L1, frameP2L2;
    [SerializeField] RectTransform frameP1, frameP2;
    [SerializeField] Image p1_icon, p2_icon;
    [SerializeField] TextMeshProUGUI p1_skillName, p2_skillName;

    public void DisableElements() {
        background.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        frameP1.localScale = new Vector3(1.0f, 0.0f, 1.0f);
        frameP1.gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        frameP2.localScale = new Vector3(1.0f, 0.0f, 1.0f);
        frameP2.gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void CastSkill(bool isPlayer, int level, float gameSpeed) {
        DisableElements();

        var backgrouneSequence = DOTween.Sequence();
        backgrouneSequence
            .Append(background.DOFade(0.8f, 0.25f * gameSpeed))
            .AppendInterval(0.6f * gameSpeed)
            .Append(background.DOFade(0.0f, 0.15f * gameSpeed));
        backgrouneSequence.Play();

        if(isPlayer) {
            var targetSkillId = DataHolder.instance.charactors[GameInfoManager.instance.currentSelectCharactorId].SkillIds[level - 1];
            p1_icon.sprite = DataHolder.instance.skillDatas[targetSkillId].icon;
            p1_skillName.text = DataHolder.instance.skillDatas[targetSkillId].name;
            switch (level){
                case 1:
                    frameP1.gameObject.GetComponent<Image>().sprite = frameP1L1;
                    break;
                case 2:
                    frameP1.gameObject.GetComponent<Image>().sprite = frameP1L2;
                    break;
            }

            var frameSequence = DOTween.Sequence();
            frameSequence
                .Append(frameP1.DOScaleY(1.0f, 0.2f * gameSpeed).SetDelay(0.1f * gameSpeed).SetEase(Ease.OutElastic))
                .AppendInterval(0.65f * gameSpeed)
                .Append(frameP1.DOScaleY(0.0f, 0.05f * gameSpeed));
            frameSequence.Play();

        } else {
            var targetSkillId = DataHolder.instance.charactors[GameInfoManager.instance.enemyCharactorId].SkillIds[level - 1];
            p2_icon.sprite = DataHolder.instance.skillDatas[targetSkillId].icon;
            p2_skillName.text = DataHolder.instance.skillDatas[targetSkillId].name;
            switch (level) {
                case 1:
                    frameP2.gameObject.GetComponent<Image>().sprite = frameP2L1;
                    break;
                case 2:
                    frameP2.gameObject.GetComponent<Image>().sprite = frameP2L2;
                    break;
            }

            var frameSequence = DOTween.Sequence();
            frameSequence
                .Append(frameP2.DOScaleY(1.0f, 0.2f * gameSpeed).SetDelay(0.1f * gameSpeed).SetEase(Ease.OutElastic))
                .AppendInterval(0.65f * gameSpeed)
                .Append(frameP2.DOScaleY(0.0f, 0.05f * gameSpeed));
            frameSequence.Play();

        }
    }
}