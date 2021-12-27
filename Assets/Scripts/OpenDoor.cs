using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject open_door, close_door, textE;
    public string triggeringTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == triggeringTag && enabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                open_door.SetActive(true);
                close_door.SetActive(false);
                textE.SetActive(false);
                
            }
        }
    }
}
