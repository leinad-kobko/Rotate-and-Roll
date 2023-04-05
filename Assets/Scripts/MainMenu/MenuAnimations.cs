using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    [Header("References")]
    public GameObject TopO;
    public GameObject BottomO;
    public Transform Orbs;
    public Transform leftIris;
    public Transform rightIris;
    Vector3 originalOrbPos;
    Vector3 originalLeftEyePos;
    Vector3 originalRightEyePos;
    float displacement;
    
    [Header("General")]
    public float oRotationSpeed = 30f;
    public float orbVerticalMax = 0.5f;
    public float orbMoveSpeed = 0.3f;
    public float eyeMovementSpeed = 0.1f;
    bool animateUp;

    private RectTransform topTransform;
    private RectTransform botTransform;

    private Vector3 rotationEuler;

    // Start is called before the first frame update
    void Start()
    {
        topTransform = TopO.GetComponent<RectTransform>();
        botTransform = BottomO.GetComponent<RectTransform>();
        
        animateUp = true;

        // Save the original positions of some of the objects
        originalOrbPos = Orbs.position;
        originalLeftEyePos = leftIris.position;
        originalRightEyePos = rightIris.position;
    }

    // Update is called once per frame
    void Update()
    {
        displacement = orbMoveSpeed * Time.deltaTime;
        RotateOs();
        OrbUpDownAnimation();
        // parallaxEye2Mouse("left");
        // parallaxEye2Mouse("right");
    }

    // Rotate the Os at oRotationSpeed degrees per second
    private void RotateOs() 
    {
        rotationEuler += Vector3.forward * oRotationSpeed * Time.deltaTime;
        topTransform.rotation = Quaternion.Euler(rotationEuler);
        botTransform.rotation = Quaternion.Euler(rotationEuler);
    }

    // Animates the orbs to bob up and down
    private void OrbUpDownAnimation()
    {
        if (animateUp) 
        {
            Orbs.Translate(Vector3.up * orbMoveSpeed * Time.deltaTime);
            if (Orbs.position.y >= (originalOrbPos.y + orbVerticalMax)) {
                animateUp = false;
            }
        } 
        else
        {
            Orbs.Translate(Vector3.down * orbMoveSpeed * Time.deltaTime);
            if (Orbs.position.y <= (originalOrbPos.y - orbVerticalMax)) {
                animateUp = true;
            }
        } 
    }

    // Animates the eyes to follow your mouse cursor
    private void parallaxEye2Mouse(string eye)
    {
        Transform eyeTransform;
        Vector2 StartPos;

        float bound = 17f;
        
        // Get Mouse Position
        Vector2 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (eye == "left") {
            eyeTransform = leftIris;
            StartPos = originalLeftEyePos;
        } else {
            eyeTransform = rightIris;
            StartPos = originalRightEyePos;
        }

        float posX = Mathf.Lerp(eyeTransform.position.x, StartPos.x + (pz.x * eyeMovementSpeed), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(eyeTransform.position.y, StartPos.y + (pz.y * eyeMovementSpeed), 2f * Time.deltaTime);

        // Code to stop iris bobbing
        // if (animateUp)
        //     posY -= (orbMoveSpeed * 2f * Time.deltaTime);
        // else
        //     posY += (orbMoveSpeed * 2f * Time.deltaTime);

        // Sets boundaries so the iris doesn't go past the eye
        if (posX > bound)
            posX = bound;
        else if (posX < (bound * -1f))
            posX = (bound * -1f);
        if (posY > bound)
            posY = bound;
        else if (posY < (bound * -1f))
            posY = (bound * -1f);

        if (eye == "left")
            leftIris.position = new Vector3(posX, posY, 0f);
        else
            rightIris.position = new Vector3(posX, posY, 0f);
    }
}
