using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    public static CommandManager instance;

    public bool canInput;
    public List<int> inputedAllows = new List<int>();

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        inputedAllows.Clear();
    }

    private void Update() {
        if (canInput) {
            if(Input.GetKeyDown(KeyCode.W)) {
                InputKey(0);
            }else if(Input.GetKeyDown(KeyCode.S)) {
                InputKey(1);
            } else if(Input.GetKeyDown(KeyCode.A)) {
                InputKey(2);
            } else if(Input.GetKeyDown(KeyCode.D)) {
                InputKey(3);
            }
        }
    }

    private void InputKey(int i) {
        ViewManager.instance.playingView.commandLinePanel.AddAllow(inputedAllows.Count, i);
        inputedAllows.Add(i);
    }

    public void ResetKeys() {
        inputedAllows.Clear();
        ViewManager.instance.playingView.commandLinePanel.ResetView();
    }
}