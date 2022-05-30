using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetTextValue(float value)
    {
        SetTextValue(value.ToString());
    }

    public void SetTextValue(int value)
    {
        SetTextValue(value.ToString());
    }

    public void SetTextValue(string value)
    {
        value = value.PadLeft(6, '0');
        _text.text = value;
    }
}
