using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Moves the object this is attached to with a Character controller and the WASD keys. 
*/
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 5.0f;
    [SerializeField] private float runningSpeed = 7.0f;
    [SerializeField] private float gravity = -9.0f;

    private CharacterController controller;
    bool shouldSleepMovement = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    float gDisp = 0.0f;
    void Update()
    {
        if (shouldSleepMovement)
            return;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //use running speed if holding shift
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed; 

        //gravity
        if (!controller.isGrounded)
            gDisp += (0.5f * gravity) * Time.deltaTime * Time.deltaTime;
        else
            gDisp = 0.0f;

        //keyboard movement
        Vector3 xMov = transform.right * xInput;
        Vector3 yMov = transform.forward * yInput;

        Vector3 move = xMov + yMov;

        if (move.magnitude > 1)
            move.Normalize();

        move *= movementSpeed * Time.deltaTime;
        move.y = gDisp;

        controller.Move(move);
    }

    //Prevents movement for a specified amount of seconds
    //Gravity is NOT applied
    public void SleepMovementSeconds(float seconds)
    {
        StartCoroutine(SleepMov(seconds));
    }

    //Internal sleep movement coroutine
    private IEnumerator SleepMov(float seconds) 
    {
        shouldSleepMovement = true;
        yield return new WaitForSeconds(seconds);
        shouldSleepMovement = false;
    }
}
