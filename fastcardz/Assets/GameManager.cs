using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_InputField cardName;
    [SerializeField] TMP_InputField cardDescription;

    [SerializeField] TMP_Text generatingText;
    [SerializeField] GameObject aiFinishButton;
    [SerializeField] GameObject completeButton;

    private IEnumerator coroutine;
    int count =0; // to count whether on deck 1 or 2
    string[] deck1name = { "Biology", "Geometry", "Physics" };
    string[] deck1desc = { "The study of all living organisms on Earth", "The study of shapes and angles in math", "The study of physical motion and energy" };
    int count1 = 0; // to count cards in deck 1
    string[] deck2name = { "Conocer", "Saber", "How do you conjugate them in yo form?" };
    string[] deck2desc = { "To have met a person or place.", "To know a fact or information.", "Conocer -> Conozco. Saber -> sé" };
    int count2 = 0; // to count cards in deck 2
    [SerializeField] TMP_Text cardNameStudy;
    [SerializeField] TMP_Text cardDescStudy;

    //make a function for clearing the board on scratch menu
    //make a function for chec


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearScratchBoard()
    {
        cardDescription.text = "";
        cardName.text = "";
    }

    public void StartDeck()
    {
        if (count == 0)
        {
            cardNameStudy.text = deck1name[count1];
            cardDescStudy.text = deck1desc[count1];
        }
        else if (count == 1)
        {
            cardNameStudy.text = deck2name[count2];
            cardDescStudy.text = deck2desc[count2];
        }
    }

    public void NextCard()
    {
        if (count == 0)
            count1++;
        else
            count2++;

        cardDescStudy.gameObject.SetActive(false);
        cardNameStudy.gameObject.SetActive(true);

        StartDeck();
    }

    public void FlipCard()
    {

        if (count == 0)
        {
            cardNameStudy.text = deck1name[count1];
            cardDescStudy.text = deck1desc[count1];
        } else
        {
            cardNameStudy.text = deck2name[count2];
            cardDescStudy.text = deck2desc[count2];
        }

        if (cardNameStudy.gameObject.activeInHierarchy)
        {
            cardDescStudy.gameObject.SetActive(true);
            cardNameStudy.gameObject.SetActive(false);
        }
        else if (!cardNameStudy.gameObject.activeInHierarchy)
        {
            cardDescStudy.gameObject.SetActive(false);
            cardNameStudy.gameObject.SetActive(true);
        }



    }

    public void FinishDeck()
    {
        count++;
    }

    public void Generate()
    {
        generatingText.gameObject.SetActive(true);
        completeButton.gameObject.SetActive(false);
        coroutine = startGeneration(generatingText, aiFinishButton);
        StartCoroutine(coroutine);
    }

    IEnumerator startGeneration(TMP_Text generatingText, GameObject button)
    {
        yield return new WaitForSeconds(10);
        generatingText.text = "Done! View your new deck in the study menu!";
        button.SetActive(true);
    }
}
