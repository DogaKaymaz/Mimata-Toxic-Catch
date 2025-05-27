using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public float spinSpeed = 100f; // degrees per second
    public bool isSpinning = false;
    private float _timeCounter = 0f;
    [SerializeField] private float initialZRotation; 
    private float _startAngle = 0f;
    private float _currentAngle = 0f;
    
    [SerializeField] private Button catchButton;
    [SerializeField] private Button spinButton;
    public void StartSpinning()
    { 
        if (isSpinning) return;
        spinButton.interactable = false;
        catchButton.interactable = true;
        isSpinning = true;
        _timeCounter = 0f;
    
        transform.localEulerAngles = new Vector3(0, 0, initialZRotation);
    }

    public void StopSpinning()
    {
        spinButton.interactable = true;
        catchButton.interactable = false;
        isSpinning = false;
    }

    public float GetCurrentAngle()
    {
        float currentZ = transform.localEulerAngles.z;

        float delta = Mathf.DeltaAngle(initialZRotation, currentZ); // -180 to 180
        float normalized = Mathf.Clamp(delta * -1f, 0f, 180f); // *-1 çünkü saat yönü

        return normalized;
    }

    void Update()
    {
        if (!isSpinning)
            return;

        _timeCounter += Time.deltaTime * spinSpeed;
        _currentAngle = Mathf.PingPong(_timeCounter, 180f);

        float angle = initialZRotation - _currentAngle;
        transform.localEulerAngles = new Vector3(0, 0, angle);   
    }
}
