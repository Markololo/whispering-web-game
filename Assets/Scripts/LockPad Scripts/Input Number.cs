using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNumber : MonoBehaviour
{

    public int inputNumber;
    public Text pinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InputPinNumber(int number)
    {
        
        //inputNumber = inputNumber * 10 + number;
        string stringNumber = number.ToString();
        pinText.text += stringNumber;
        if(pinText.text.Length > 4)
        {
            pinText.text = pinText.text.Substring(pinText.text.Length - 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
