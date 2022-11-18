using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReaction : MonoBehaviour
{
    public FloatValue playerMagic;
    public Signals magicSignal;

    public void Use(int amountToIncrease)
    {
        playerMagic.runtimeValue += amountToIncrease;
        magicSignal.Raise();
    }
}
