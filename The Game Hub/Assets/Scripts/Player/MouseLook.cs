using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform PlayerBody;
    // The main variables (like sensitivity, etc)
    public float Sensitivity = 100f;

    private float _xRotation = 0f;

    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}