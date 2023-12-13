using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public GameObject myPrefab;
    bool isPressed;

    void Start()
    {
        isPressed = false;  
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!isPressed) 
        {
            presser=Other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject==presser) 
        {
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnSphere()
    {
        GameObject go=Instantiate(myPrefab, new Vector3(0.28f, 1, 0.3f), Quaternion.identity);
        go.transform.localScale = new Vector3(0.08f,0.08f,0.08f);

        /*
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
         */

    }

}
