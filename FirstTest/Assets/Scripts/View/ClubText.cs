using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClubText : MonoBehaviour
{
    public string clubname = "";
    private TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        uiText.text = "Current Club: " + clubname;
    }
}
