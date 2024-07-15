using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandLinePanel : MonoBehaviour {
    public List<Image> allowImages;
    public List<Sprite> allowSprites;

    public void ResetView() {
        foreach(var image in allowImages) {
            image.enabled = false;
        }
    }

    public void AddAllow(int index, int vec) {
        allowImages[index].enabled = true;
        allowImages[index].sprite = allowSprites[vec];
    }
}