using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour {
    [SerializeField] private List<Image> digit_10 = new List<Image>();
    [SerializeField] private List<Image> digit_1 = new List<Image>();

    public void Set(float _num) {
        foreach(var item in digit_10) {
            item.gameObject.SetActive(false);
        }foreach(var item in digit_1) {
            item.gameObject.SetActive(false);
        }
        int num = (int)_num;
        digit_10[num / 10].gameObject.SetActive(true);
        digit_1[num % 10].gameObject.SetActive(true);
    }
}