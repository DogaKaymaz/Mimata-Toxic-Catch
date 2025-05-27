using System;
using UnityEngine;

public class Sandal : MonoBehaviour
{
    private bool _isPlayerHere;
    [SerializeField] private CharacterMovement characterMovement;

    public Action<bool> PlayerNear;

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