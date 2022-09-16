using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    float verticalValue;
    public int buttonIndex = 0;
    [SerializeField] bool isPressed = false;
    [SerializeField] int minIndex = 0;
    [SerializeField] int maxIndex = 2;

    // Update is called once per frame
    void Update()
    {
        verticalValue = Input.GetAxis("Vertical");
        if (verticalValue != 0)
        {
            //Debug.Log(verticalValue);

            //bir defa butona bas�ld�m� kontrol�
            if (!isPressed)
            {
                //butonlar aras�ndaki ge�i�in d�ng� haline getirildi�i b�l�m
                // W ve �st ok tu�una bas�ld���nda
                if (verticalValue > 0)
                {
                    if (buttonIndex != maxIndex)
                    {
                        buttonIndex++;
                    }
                    else
                    {
                        buttonIndex = minIndex;
                    }
                }
                // S ve alt ok tu�u bas�ld���nda
                else if (verticalValue < 0)
                {
                    if(buttonIndex != minIndex)
                    {
                        buttonIndex--;
                    }
                    else
                    {
                        buttonIndex = maxIndex;
                    }
                }

                isPressed = true;
            }

        }
        else
        {
            isPressed = false;
        }
    }
}
