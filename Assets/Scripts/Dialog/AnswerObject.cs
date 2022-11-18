using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;
    private int chioceValue;

    public void Setup(string newDialog, int myChioce)
    {
        myText.text = newDialog;
        chioceValue = myChioce;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
