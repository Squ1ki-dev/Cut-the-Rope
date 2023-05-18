using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreCounter;
    public int counter;
    public GameObject winningState;

    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            counter++;
            scoreCounter.text = counter.ToString();
        }

        if(counter >= 100){
            Win();
            counter = 100;
            scoreCounter.text = counter.ToString();
        }
    }

    void Win(){
        winningState.SetActive(true);
        Debug.Log("Win");
    }
}
