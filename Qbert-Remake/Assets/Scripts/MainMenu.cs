using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject rules;
    public void PlayGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.gameStart = true;
    }

    public void ShowRules()
    {
        rules.SetActive(true);
    }
}
