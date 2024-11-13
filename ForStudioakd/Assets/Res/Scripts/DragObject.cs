using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public float maxDistance = 3f; 
    public Transform holdParent;
    private GameObject draggedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (draggedObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (draggedObject != null)
        {
            draggedObject.transform.position = holdParent.position;
            draggedObject.GetComponent<Collider>().enabled = false;
            draggedObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void TryPickUpObject()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Drag"))
            {

                draggedObject = hit.collider.gameObject;
                
            }
        }
    }

    private void ReleaseObject()
    {
        if (draggedObject != null)
        {
            draggedObject.GetComponent<Rigidbody>().isKinematic = false;
            draggedObject.GetComponent<Collider>().enabled = true;
            draggedObject = null;


        }
    }
}
