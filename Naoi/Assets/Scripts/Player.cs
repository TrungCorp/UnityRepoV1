using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController playerController;
    public float speed = 3f;
    public Transform myCameraHead;
    float mouseSensitivity = 700f;
    float cameraVerticalRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CamRotation();
    }

    //method controls the movement
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = x * transform.right + y* transform.forward;
        movement = movement * speed *Time.deltaTime;
        playerController.Move(movement);
    }

    //camera functions
    void CamRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y")*mouseSensitivity*Time.deltaTime;

        cameraVerticalRotation -=mouseY;    
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation,-90f, 90f);

        transform.Rotate(Vector3.up *mouseX);
        myCameraHead.localRotation = Quaternion.Euler(cameraVerticalRotation,0f,0f);
    }

}
