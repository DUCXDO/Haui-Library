
using UnityEngine;

public class OpenDoorScript : MonoBehaviour {
    public GameObject Door;
    public bool DoorState = false;

    public void OpenDoor()
    {
        Animator ani = Door.GetComponent<Animator>();
        if (ani != null)
        {
            ani.SetTrigger("OpenDoor");
            if(DoorState == false)
            {
                DoorState = true;
            }
            else
            {
                DoorState = false;
            }
        }
    }


}
