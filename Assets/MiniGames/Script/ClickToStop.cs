using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickToStop : MonoBehaviour
{
    public List<Sprite> myAnswer;
    public List<Sprite> correctAnswer;
    public Image ImageCorrect, ImageAnswer;
    public int counter;
    public int AnswerInt, CorrectAnswerInt;
    public TextMeshProUGUI clue;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0,5);
        ImageCorrect.sprite = correctAnswer[rand];
        InvokeRepeating("ChangeSprite",1,1);
        CorrectAnswerInt = rand;
    }

    public void ChangeSprite(){
        counter++;
        if(counter >= myAnswer.Count){
            counter = 0;
        }

        ImageAnswer.sprite = myAnswer[counter];
        AnswerInt = counter;
    }

    public void Pause(){
        CancelInvoke("ChangeSprite");

        if(AnswerInt == CorrectAnswerInt){
            clue.text = "=";
        }
        else{
            clue.text = "!=";
        }
        
    }

    public void UnPause(){
        InvokeRepeating("ChangeSprite",1,1);
    }

}
