using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    public bool State;
    private void Start()
    {
        if (State == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    /* public bool cursorState;
     public void Cursors(bool cursorState)
     {
         Cursor.visible = cursorState;
     }*/
}
