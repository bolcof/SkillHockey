using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleView : MonoBehaviour {

    public void PushStart() {
        ViewManager.instance.charactorSelectView.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}