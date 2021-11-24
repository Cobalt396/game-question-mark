using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject mainCharacterPortrait;
    public GameObject textBox;
    public TextMeshPro clickToContinueText;
    public TextMeshPro mainCharacterText1;  
    public TextMeshPro squirrelText1;
    public TextMeshPro squirrelText2;
    public TextMeshPro squirrelText3;
    public TextMeshPro squirrelText4;
    private bool textIsPlayed = false;
    public bool continueText = false;
    // Set canContinue to false after dialogue has been finalized
    public bool canContinue = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.Find("snowyowlsprite");
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCharacter.transform.position.x > 3 && textIsPlayed == false)
        {
            textBox.SetActive(true);
            mainCharacterPortrait.SetActive(true);
            squirrelText1.gameObject.SetActive(true);
            textIsPlayed = true;
            StartCoroutine(DialogueRoutine());
        }
    }

    IEnumerator DialogueRoutine()
    {
        yield return new WaitForSeconds(2);
        mainCharacterText1.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2);
        squirrelText2.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        squirrelText3.gameObject.SetActive(true);
        clickToContinueText.gameObject.SetActive(true);

        // Add click to continue functionality
        // yield return new WaitUntil(continueText = true);

        // delete this after above is completed
        yield return new WaitForSeconds(5);
        squirrelText1.gameObject.SetActive(false);
        squirrelText2.gameObject.SetActive(false);
        squirrelText3.gameObject.SetActive(false);
        squirrelText4.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        textBox.SetActive(false);    
        mainCharacterPortrait.SetActive(false);
        clickToContinueText.gameObject.SetActive(false);
        mainCharacterText1.gameObject.SetActive(false);
        squirrelText4.gameObject.SetActive(false);
        canContinue = true;
    }

    void OnMouseDown()
    {
        Debug.Log("awef;");
        continueText = true;
    }

    public bool GetTextIsPlayed()
    {
        return textIsPlayed;
    }
}
