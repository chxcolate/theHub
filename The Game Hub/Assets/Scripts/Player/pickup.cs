using UnityEngine;

public class pickup : MonoBehaviour
{
[Header("Guide Variables")]
    public Transform guide;
    public GameObject guideGameObject;
    bool pickedUpObject;


    Quaternion originalRotation;

    // Update is called once per frame
    void Update()
    {
        if(pickedUpObject) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            originalRotation = transform.rotation;
            this.transform.rotation = originalRotation;
            this.transform.position = guide.position;
        }
    }

    void OnMouseOver() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(!pickedUpObject) {
                
                //GetComponent<Rigidbody>().detectCollisions = false;
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = guide.position;
                this.transform.parent = guideGameObject.transform;
                pickedUpObject = true;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.E)) {
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                //GetComponent<Rigidbody>().detectCollisions = true;
                originalRotation = transform.rotation;
                pickedUpObject = false;
                
        }
    }
}
