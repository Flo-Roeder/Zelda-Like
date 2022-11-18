using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    public Inventory playerInventory;

    public void UpdateCoin()
    {
        coinText.text = ""+ playerInventory.coins;
    }
}
