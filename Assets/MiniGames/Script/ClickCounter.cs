using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tools;

public class ClickCounter : WindowBase
{
    public TextMeshProUGUI scoreCounter;
    public int counter;
    public GameObject winningState;

    public System.Action onComplete;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter++;
            scoreCounter.text = counter.ToString() + "/100";
        }

        if (counter >= 100)
        {
            Win();
            counter = 100;
            scoreCounter.text = counter.ToString() + "/100";
        }
    }

    void Win()
    {
        Close();
        onComplete?.Invoke();
        winningState.SetActive(true);
        Debug.Log("Win");
    }
}
