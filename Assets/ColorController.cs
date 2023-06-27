using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ColorController : MonoBehaviour
{
    public Material[] wallMaterial;
    Renderer rend;
    public Transform targetObject;
    public Rigidbody rb;

    public Vector3 originalPosition;
    float timer;
    public float delay = 3;
    public TextMeshProUGUI displayText;

    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        Console.Write(timer.ToString(), delay);
        // Assigns the component's renderer instance
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    // Called when the ball collides with the wall
    private IEnumerator OnCollisionEnter(Collision col)
    {
        // Checks if the player ball has collided with the wall.
        if (col.gameObject.name == "player-ball")
        {

            rend.sharedMaterial = wallMaterial[0];
            rb.constraints = RigidbodyConstraints.FreezeAll;

            displayText.text = "Collision";
            yield return new WaitForSeconds(0.5f);
            
            targetObject.position = originalPosition;




        }
    }
    // It is called when the ball moves away from the wall
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "player-ball")
        {
            displayText.text = "Keep Rolling";
            rend.sharedMaterial = wallMaterial[1];
            rb.constraints = RigidbodyConstraints.None;

        }
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(5.0f);
    }

    
}