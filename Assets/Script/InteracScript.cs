using UnityEngine;
using UnityEngine.UI;

public class InteracScript : MonoBehaviour
{
    public Camera camera;
    public float range = 10f;
    public Text interactText;
    public KeyCode InteractKey = KeyCode.F;
    // Update is called once per frame
    void Update()
    {

        ShowTarget();

    }

    void ShowTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            InteractableObject obj = hit.transform.GetComponent<InteractableObject>();
            
            if (obj != null)
            {
                OpenDoorScript ods = hit.transform.GetComponent<OpenDoorScript>();
                if (ods != null)
                {
                    if (ods.DoorState == false)
                    {
                        interactText.text = "Press 'F' to open door";
                        interactText.enabled = true;
                    }
                    else
                    {
                        interactText.text = "Press 'F' to close door";
                        interactText.enabled = true;
                    }
                }
                else
                {
                    interactText.text = "Press 'F' to interact";
                    interactText.enabled = true;
                }
            }
            if (Input.GetKeyDown(InteractKey) == true)
            {
                Interact();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            InteractableObject obj = hit.transform.GetComponent<InteractableObject>();
            if (obj != null)
            {
                OpenDoorScript ods = hit.transform.GetComponent<OpenDoorScript>();
                if (ods != null)
                {
                    ods.OpenDoor();
                }

            }
        }
    }
}
