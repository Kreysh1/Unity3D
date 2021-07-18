using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPickup;
    public GameObject pickedObject;
    public Transform interactionZone;

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickup != null && ObjectToPickup.GetComponent<PickableObject>().isPickable == true && pickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedObject = ObjectToPickup;
                pickedObject.GetComponent<PickableObject>().isPickable = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.transform.position = interactionZone.position;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }   
        }
        else if (pickedObject != null)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("soltar");
                pickedObject.GetComponent<PickableObject>().isPickable = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject = null;
            }
        }
    }
}
