using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float speed;

    [SerializeField]
    float leapSpeed;

    [SerializeField]
    float jumpPower;

    [SerializeField]
    PlayerReticle reticle;

    //bool shouldJump;

    Vector2 force;

    bool shouldFireRight;

    bool shouldFireLeft;

    float leapSecondsElapsed;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        leapSecondsElapsed = Mathf.Max(leapSecondsElapsed - Time.deltaTime, 0);
        if (shouldFireRight)
        {
            player.RightWeapon.Fire();
        }
        if (shouldFireLeft)
        {
            player.LeftWeapon.Fire();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddForce();
    }

    void AddForce()
    {
        if (leapSecondsElapsed == 0 && force != Vector2.zero)
        {
            body.AddForce(force * speed, ForceMode2D.Impulse);
        }
        else if (leapSecondsElapsed > 0 && force != Vector2.zero)
        {
            body.velocity = force.normalized * leapSpeed;
        }
        // if (shouldJump)
        // {
        //     shouldJump = false;
        //     var vector = new Vector2(0, jumpPower);
        //     //Debug.LogWarning("Jump Vector: " + vector);
        //     body.AddForce(vector, ForceMode2D.Impulse);
        // }
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        force = context.ReadValue<Vector2>();
        //Debug.LogWarning("Movement Vector: " + force);
        //force.y = force.y > 0 ? 0 : force.y;
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //shouldJump = true;
        }
    }

    public void HandleFire1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shouldFireLeft = true;
        }
        else if (context.canceled)
        {
            shouldFireLeft = false;
        }
    }

    public void HandleFire2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shouldFireRight = true;
        }
        else if (context.canceled)
        {
            shouldFireRight = false;
        }
    }

    public void HandleMouseMove(InputAction.CallbackContext context)
    {
        var pos = context.ReadValue<Vector2>();
        //Debug.LogWarning("Mouse: " + pos);
        reticle.SetPosition(pos);
    }

    public void HandleRightStickMove(InputAction.CallbackContext context)
    {
        var pos = context.ReadValue<Vector2>();
        //Debug.LogWarning("Controller: " + pos);
        reticle.SetPositionController(pos);
    }

    public void AddLeapSeconds(float toAdd)
    {
        leapSecondsElapsed += toAdd;
    }
}
