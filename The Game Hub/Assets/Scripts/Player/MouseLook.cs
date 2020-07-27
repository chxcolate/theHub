 using UnityEngine;
 
 public class MouseLook : MonoBehaviour
 {
 
     public Transform playerBody;
 
 
     // The main variables (like sensitivity, etc)
     public float sensitivity = 100f;
     float xRotation = 0f;
 
     // Start is called before the first frame update
     void Start() {
        Cursor.lockState = CursorLockMode.Locked;
     }

// Update is called once per frame
     void Update()
     {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
     }
 }
 
