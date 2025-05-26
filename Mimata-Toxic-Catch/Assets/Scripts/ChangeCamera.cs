using UnityEngine;
using UnityEngine.Serialization;

public class ChangeCamera : Singleton<ChangeCamera>
{
    public Camera homeCam;
    public Camera seaCam;
    
    public void SetHomeCam()
    {
        seaCam.gameObject.SetActive(false);

        homeCam.gameObject.SetActive(true);

    }
    public void SetSeaCam()
    {
        homeCam.gameObject.SetActive(false);

        seaCam.gameObject.SetActive(true);

    }
}