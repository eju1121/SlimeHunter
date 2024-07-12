using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeName : MonoBehaviour
{
    [SerializeField] private Text slimeNameText;

    public void ChangeSlimeName(string name)
    {
        slimeNameText.text = name;
    }

    
}
