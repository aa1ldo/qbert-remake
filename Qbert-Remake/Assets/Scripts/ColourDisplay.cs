using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourDisplay : MonoBehaviour
{
    RawImage image;

    private void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        image.color = GameManager.Instance.targetColour;
    }
}
