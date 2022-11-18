using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactible
{
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private TextAsset npcDialog;
    [SerializeField] private Signals dialogSignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Weapon"))
            {
                dialogValue.value = npcDialog;
                dialogSignal.Raise();
            }
        }
    }
}
