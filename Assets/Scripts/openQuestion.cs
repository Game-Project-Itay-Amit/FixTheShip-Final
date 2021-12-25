using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openQuestion : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public GameObject btn1, btn2, btn3, btn4, qText, pic;
    public Canvas myCanvas;
    private void OnTriggerStay(Collider other) {

            if (other.tag == triggeringTag && enabled)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    btn1.SetActive(true);
                    btn2.SetActive(true);
                    btn3.SetActive(true);
                    btn4.SetActive(true);
                    qText.SetActive(true);
                    pic.SetActive(true);
                }
        }
    }

    private void OnTriggerExit(Collider other) {

            if (other.tag == triggeringTag && enabled)
            { 
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
                btn1.SetActive(false);
                btn2.SetActive(false);
                btn3.SetActive(false);
                btn4.SetActive(false);
                qText.SetActive(false);
                pic.SetActive(false); 
        }
    }
    void Update()
    {
        
    }
}
