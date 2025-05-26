using System;
using UnityEngine;

public class Sandal : MonoBehaviour
{
    private bool _isPlayerHere;
    [SerializeField] private CharacterMovement characterMovement;

    public Action<bool> PlayerNear;
    private void Update()
    {
        if(!_isPlayerHere) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeCamera.Instance.SetSeaCam();
            if (characterMovement != null) characterMovement.canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            _isPlayerHere = true;
            PlayerNear?.Invoke(_isPlayerHere);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            _isPlayerHere = false;
            PlayerNear?.Invoke(_isPlayerHere);
        }
    }
}