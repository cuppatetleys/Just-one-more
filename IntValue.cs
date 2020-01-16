using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    [HideInInspector]
    public int RunTimeValue;

    public void OnAfterDeserialize()
    {
        RunTimeValue = initialValue;
    }

    public void OnBeforeSerialize() { }
}
