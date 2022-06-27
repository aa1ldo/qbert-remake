using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text text;
    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        text.text = GameManager.Instance.score.ToString();
    }
}
