using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Guide Variables")]
    public Transform Guide;
    public GameObject GuideGameObject;

    private Quaternion _originalRotation;
    private bool _pickedUpObject;

    // Update is called once per frame
    public void Update()
    {
        if (_pickedUpObject)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            _originalRotation = transform.rotation;
            transform.rotation = _originalRotation;
            transform.position = Guide.position;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_pickedUpObject)
            {
                GetComponent<Rigidbody>().useGravity = false;
                transform.position = Guide.position;
                transform.parent = GuideGameObject.transform;
                _pickedUpObject = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            _originalRotation = transform.rotation;
            _pickedUpObject = false;
        }
    }
}
