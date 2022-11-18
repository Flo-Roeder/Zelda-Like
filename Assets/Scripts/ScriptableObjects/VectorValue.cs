using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value running InGame")]
    public Vector2 initialValue;

    [Header("Value default by start")]
    public Vector2 defaultValue;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {

    }
}
