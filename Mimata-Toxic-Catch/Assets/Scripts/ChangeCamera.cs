using UnityEngine;
using UnityEngine.Serialization;

public class ChangeCamera : Singleton<ChangeCamera>
{
    public Camera homeCam;
    public Camera seaCam;

    [SerializeField] private CharacterMovement characterMovement;
    
    public void SetHomeCam()
    {
        seaCam.gameObject.SetActive(false);
        characterMovement.canMove = true;
        homeCam.gameObject.SetActive(true);

    }
    public void SetSeaCam()
    {
        homeCam.gameObject.SetActive(false);
        characterMovement.canMove = false;
        seaCam.gameObject.SetActive(true);
    }
}