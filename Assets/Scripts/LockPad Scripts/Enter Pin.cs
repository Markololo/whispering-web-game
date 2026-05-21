using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPin : MonoBehaviour
{
    public string pinCode; // i put it public so you guys can change it whenever but if it messes with the build we can make it private;
    public Text pinEntered;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CheckPinMatch()
    {
         string inputEntered = pinEntered.text.Trim(); 

        if(inputEntered.Length != pinCode.Length)
        {
            Debug.Log("Pin does not match. Try again.");
          
        }
        if (inputEntered == pinCode)
        {
            Debug.Log("Pin Matched!");
          
        }
        else
        {
            Debug.Log("Pin does not match. Try again.");
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
