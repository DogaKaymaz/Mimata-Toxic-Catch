using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    
    public Action<string, float> characterMoved;
    
    private Vector2 _movement;
    private float lastMoveX;
    private float lastMoveY;

    public bool canMove = true;

    private void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove) MoveCharacter();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void MoveCharacter()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
      
        characterMoved?.Invoke("Horizontal", _movement.x);
        characterMoved?.Invoke("Vertical", _movement.y);
        characterMoved?.Invoke("Speed", _movement.sqrMagnitude);
        
        if (_movement != Vector2.zero)
        {
            lastMoveX = _movement.x;
            lastMoveY = _movement.y;
            
            characterMoved?.Invoke("LastHorizontal", lastMoveX);
            characterMoved?.Invoke("LastVertical", lastMoveY);
        }
    }


    //this was for 3D but I switched to 2D
    // private void MoveCharacter()
    // {
    //     float horizontal = Input.GetAxis("Horizontal");
    //     float vertical = Input.GetAxis("Vertical");
    //     if (horizontal == 0 && vertical == 0) return;
    //     Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    //     rb.linearVelocity = moveDirection * moveSpeed;
    //     transform.rotation = Quaternion.LookRotation(moveDirection);
    // }
}