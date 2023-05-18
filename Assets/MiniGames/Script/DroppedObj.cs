using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedObj : MonoBehaviour
{
    public List<Sprite> listCharacter;
    public Image answer1,answer2,answer3;
    public string[] characterName;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0,listCharacter.Count);
        GetAnswer1(rand);
    }

    void GetAnswer1(int val){
        answer1.sprite = listCharacter[val];
        answer1.name = characterName[val];
        GetAnswer2(val);
    }
    
    void GetAnswer2(int val){
        int newRand;
        do
        {
            newRand = Random.Range(0, listCharacter.Count);
        }

        while (newRand == val);
        answer2.sprite = listCharacter[newRand];
        answer2.name = characterName[newRand];
        GetAnswer3(val, newRand);
    }

    void GetAnswer3(int val, int newVal){
        int newRand;
        do
        {
            newRand = Random.Range(0, listCharacter.Count);
        }
        while (newRand == val || newRand == newVal); 
        answer3.sprite = listCharacter[newRand];
        answer3.name = characterName[newRand];
    }
    
}
