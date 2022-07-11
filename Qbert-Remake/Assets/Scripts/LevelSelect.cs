using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            GameManager.Instance.continuedToLevel = true;
        }
    }
}
