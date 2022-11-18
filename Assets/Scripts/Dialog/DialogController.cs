using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject answerPrefab;
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private Story myStory;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject answerHolder;
    [SerializeField] private ScrollRect dialogScroll;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCanvas()
    {
        dialogCanvas.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if (dialogValue.value)
        {
            DeleteOldDialogs();
            myStory = new Story(dialogValue.value.text);
        }
        
    }

    private void DeleteOldDialogs()
    {
        for (int i = 0; i < dialogHolder.transform.childCount; i++)
        {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
    }

    public void RefreshView()
    {
        while (myStory.canContinue)
        {
        MakeNewDialog(myStory.Continue());
        }
        if (myStory.currentChoices.Count>0)
        {
            MakeNewChioces();
        }
        else
        {
            dialogCanvas.SetActive(false);
        }
        StartCoroutine(ScrollCo());
    }

    private IEnumerator ScrollCo()
    {
        yield return null;
        dialogScroll.verticalNormalizedPosition = 0;
    }

    private void MakeNewDialog(string newDialog)
    {
        DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DialogObject>();
        newDialogObject.Setup(newDialog);
    }

    private void MakeNewAnswer(string newDialog, int answerValue)
    {
        AnswerObject newAnswerObject = Instantiate(answerPrefab, answerHolder.transform).GetComponent<AnswerObject>();
        newAnswerObject.Setup(newDialog,answerValue);
        Button answerButton = newAnswerObject.gameObject.GetComponent<Button>();
        if (answerButton)
        {
            answerButton.onClick.AddListener(delegate { ChooseChioce(answerValue); });
        }
    }

    private void MakeNewChioces()
    {
        for (int i = 0; i < answerHolder.transform.childCount; i++)
        {
            Destroy(answerHolder.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewAnswer(myStory.currentChoices[i].text, i);
        }
    }

    private void ChooseChioce(int chioce)
    {
        myStory.ChooseChoiceIndex(chioce);
        RefreshView();
    }

}
