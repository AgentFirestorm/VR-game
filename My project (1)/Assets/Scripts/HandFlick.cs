using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HandFlick : MonoBehaviour
{
    public InputActionReference flickinput;
    public InputActionReference controllerposition;
    public Transform BallTransform;
    public Rigidbody ballrb;
    public float RecallForce;
    public bool ShouldBallComeTowardsPlayer;
    public XRDirectInteractor Interactor;
    public XRGrabInteractable BallInteractable;
    public XRInteractionManager InteractionManager;

    private Vector3 lastposition;
    private Vector3 currentvelocity;
    private Vector3 lastvelocity;
    public float flickforce;
    private Vector3 currentacceleration;
    private Vector3 direction;
    private float FlickTimer;
    private bool IsButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        flickinput.action.started += ActivateFlick;
        flickinput.action.canceled += DeactivateFlick;
        Interactor.selectExited.AddListener(ActivateGravity);
        // lastposition = 

    }

    // Update is called once per frame
    void Update()
    {




        direction = transform.position - BallTransform.position;
        direction.Normalize();

        Vector3 currentposition = controllerposition.action.ReadValue<Vector3>();
        currentvelocity = (currentposition - lastposition) / Time.deltaTime;
        //currentacceleration = (currentvelocity - lastvelocity) / Time.deltaTime;

        lastposition = currentposition;

        if (IsButtonPressed)
        {
            FlickTimer += Time.deltaTime;
        }

        // float distancetoball = Vector3.Distance(transform.position, BallTransform.position);
        //  if (distancetoball<0.25f)
        // {

        //   InteractionManager.SelectEnter(Interactor, (IXRSelectInteractable)BallInteractable);
        //   ShouldBallComeTowardsPlayer = false;

        //  }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);


    }
   
    void ActivateFlick(InputAction.CallbackContext ctx)
    {
        
        ShouldBallComeTowardsPlayer = true;
        
        lastvelocity = currentvelocity;
        FlickTimer = 0;
        IsButtonPressed = true;
        
    }
    void DeactivateFlick(InputAction.CallbackContext ctx)
    {
        
        ShouldBallComeTowardsPlayer = false;
        
        IsButtonPressed = false;
        currentacceleration = (currentvelocity - lastvelocity) / FlickTimer;
        Debug.DrawRay(ballrb.transform.position, currentacceleration, Color.red, 600);
        Debug.Log(currentacceleration);
        ballrb.AddForce(currentacceleration * flickforce,ForceMode.VelocityChange);
    }
    void ActivateGravity(SelectExitEventArgs e)
    {
       
    }
}
