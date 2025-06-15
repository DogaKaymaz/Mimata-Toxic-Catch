using System;
using UnityEngine;

public class SpriteAlphaChecker : MonoBehaviour
{
    // private SpriteRenderer _spriteRenderer => GetComponent<SpriteRenderer>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>()
            && transform.localPosition.y < GameManager.Instance.mcMovement.transform.position.y)
        {
            GetComponent <SpriteRenderer> ().color = new Color (1, 1, 1, 1f);
        }
        else if (other.GetComponent<CharacterMovement>()
                 && transform.localPosition.y < GameManager.Instance.mcMovement.transform.position.y)
        {
            GetComponent <SpriteRenderer> ().color = new Color (1, 1, 1, 0f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            GetComponent <SpriteRenderer> ().color = new Color (1, 1, 1, 0f);
        }
    }
}