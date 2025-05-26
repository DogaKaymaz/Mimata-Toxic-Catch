using System;
using UnityEngine;
[RequireComponent(typeof(CharacterMovement))]
public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    //[SerializeField] private CharacterBehaviour characterBehaviour;
    [SerializeField] private Animator animator;

    private void Start()
    {
        characterMovement.characterMoved += OnCharacterMoved;
  //      characterBehaviour.characterWatering += OnCharacterWatering;
    }

    private void OnCharacterMoved(string movementType, float amount)
    {
        animator.SetFloat(movementType, amount);
    }
    
    private void OnCharacterWatering(bool isWatering, float posDif)
    {
        characterMovement.canMove = !isWatering;
        animator.SetFloat("Direction", posDif);
        animator.SetBool("isWatering", isWatering);
    }
}
