using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public float levelRotationSpeed = -50;
    private Vector3 rotationEuler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Rotating Right");
            rotationEuler += Vector3.forward * levelRotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotationEuler);
        }
        // Rotate Left
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Rotating Left");
            rotationEuler += -1f * Vector3.forward * levelRotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotationEuler);
        }
    }
}
