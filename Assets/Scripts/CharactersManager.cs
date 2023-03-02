using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public GameObject panelCharacter;
    public int count;

    public void CharacterOne()
    {
        count = 1;
        ResultCharacter();
    }
    public void CharacterTwo()
    {
        count = 2;
        ResultCharacter();
    }
    public void CharacterThree()
    {
        count = 3;
        ResultCharacter();
    } 

    public void ResultCharacter()
    {
        if (count==1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("IsometricDiamond");
        }
        else if(count==2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Mobile - Flappy Bird - Version 12 Sprites");
        }
        else if(count==3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Mobile - Flappy Bird - Version 12 Sprites");
        }
        panelCharacter.SetActive(false);
    }
}
