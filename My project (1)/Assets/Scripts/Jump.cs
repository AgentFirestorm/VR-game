using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public InputActionReference JumpAction;
    public CharacterController controller;
    private float yvelocity;
    public float JumpForce;
    public int MaxJumps;
    private int Numberofjumpsleft;
    // Start is called before the first frame update
    void Start()
    {
        JumpAction.action.started += jump;
        Numberofjumpsleft = MaxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded&& yvelocity<0)
        {
            yvelocity = 0;
        }
        yvelocity -= 9.81f * Time.deltaTime;
        controller.Move(new Vector3(0, yvelocity * Time.deltaTime, 0));
        if (controller.isGrounded)
        {
            Numberofjumpsleft = MaxJumps;
        }
    }
    public void jump(InputAction.CallbackContext TCX)
    {
        if (controller.isGrounded)
        {
            print("Yahoo i jumped");
            yvelocity = JumpForce;
        }
        else if (Numberofjumpsleft>0)
        {
            print("Yahoo i jumped");
            yvelocity = JumpForce;
            Numberofjumpsleft -= 1;
        }
        
    }
}
