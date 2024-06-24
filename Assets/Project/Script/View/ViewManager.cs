using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour {
    public static ViewManager instance;

    public TitleView titleView;
    public CharactorSelectView charactorSelectView;
    public PlayingView playingView;
    public ResultView resultView;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        titleView.gameObject.SetActive(true);
        charactorSelectView.gameObject.SetActive(false);
        playingView.gameObject.SetActive(false);
        resultView.gameObject.SetActive(false);
    }
}
