using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform commandPnl;
    public Transform anchor;
    public float offset;
    public bool swt;
    public float smoothSpeed = 0.2f;

    void Start()
    {
        swt = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!swt)
        {   
            Vector3 pos = commandPnl.position - transform.forward * offset;
            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
            //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, commandPnl.rotation.eulerAngles, smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, commandPnl.rotation, smoothSpeed);
            //transform.rotation = commandPnl.rotation;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, anchor.position, smoothSpeed);
            //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, anchor.rotation.eulerAngles, smoothSpeed);
            //transform.rotation = Quaternion.Lerp(transform.localRotation, anchor.localRotation, smoothSpeed);
            transform.localRotation = anchor.localRotation;
        }
        
    }

    public void cameraPos()
    {
        swt = !swt;
    }
}
