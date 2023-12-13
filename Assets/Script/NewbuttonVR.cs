using UnityEngine;
using UnityEngine.Events;

public class ClockButton : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public ChessClock chessClock; // Reference to the Chess Clock script
    private GameObject presser;
    private bool isPressed;

    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
