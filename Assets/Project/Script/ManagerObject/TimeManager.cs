using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public static TimeManager instance;

    public float defaultTimeLimit;
    public float currentTimeLimit;
    public bool isPlaying;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        isPlaying = false;
    }
    public void SetFirst() {
        currentTimeLimit = defaultTimeLimit;
        ViewManager.instance.playingView.setTime(defaultTimeLimit);
        isPlaying = true;
    }

    private void Update() {
        if(isPlaying) {
            currentTimeLimit -= Time.deltaTime;
            ViewManager.instance.playingView.setTime(currentTimeLimit);
            if(currentTimeLimit < 0 ) {
                isPlaying = false;
                currentTimeLimit = 0;
            }
        }
    }
}