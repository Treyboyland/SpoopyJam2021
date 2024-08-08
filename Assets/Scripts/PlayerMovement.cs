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
    float jumpPower;

    [SerializeField]
    PlayerReticle reticle;

    Vector2 force;

    // Update is called once per frame
    void Update()
    {
        AddForce();
    }

    void AddForce()
    {
        if (force != Vector2.zero)
        {
            body.AddForce(force * speed, ForceMode2D.Impulse);
        }
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        force = context.ReadValue<Vector2>();
        //Debug.LogWarning("Movement Vector: " + force);
        force.y = force.y > 0 ? 0 : force.y;
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var vector = new Vector2(0, jumpPower);
            //Debug.LogWarning("Jump Vector: " + vector);
            body.AddForce(vector, ForceMode2D.Impulse);
        }
    }

    public void HandleFire1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            player.LeftWeapon.Fire();
        }
    }

    public void HandleFire2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            player.RightWeapon.Fire();
        }
    }

    public void HandleMouseMove(InputAction.CallbackContext context)
    {
        var pos = context.ReadValue<Vector2>();
        //Debug.LogWarning("Mouse: " + pos);
        reticle.SetPosition(pos);
    }
}
