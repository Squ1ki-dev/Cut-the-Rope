using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessName : MonoBehaviour
{
    public Image outputImage;
    public List<Sprite> characters;
    public string[] characterName;
    public TextMeshProUGUI btnText1, btnText2, GuessedText;
    public Button btn1, btn2;
    public string answer;
    public int rand;

    void Start()
    {
        int rand = Random.Range(0, characters.Count);
        outputImage.sprite = characters[rand];
        answer = characterName[rand];

        int randButton = Random.Range(0, 2);
        if (randButton == 0)
        {
            btnText1.text = answer;
            btnText2.text = GetRandomCharacterName(rand);
        }
        else
        {
            btnText1.text = GetRandomCharacterName(rand);
            btnText2.text = answer;
        }
    }

    public void Btn1()
    {
        CheckAnswer(btn1.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    public void Btn2()
    {
        CheckAnswer(btn2.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    private void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == answer)
        {
            GuessedText.text = "CORRECT";
        }
        else
        {
            GuessedText.text = "WRONG";
        }
    }

    private string GetRandomCharacterName(int val)
    {
        int newRand;

        do
        {
            newRand = Random.Range(0, characterName.Length);
        }

        while (newRand == val);

        return characterName[newRand];
        
    }
}
