using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public float speedmov;
    public float speedrot;
    public float xrot;
    public float yrot;
    public float smoothSpeed = 0.2f;
    public bool isDef;
    public Transform defPos;
    public TMPro.TMP_InputField inputField;
    public Slider timeSlider;
    public Transform maxPos;
    public Transform minPos;
    private void Awake()
    {
        xrot = transform.localRotation.x;
        yrot = transform.localRotation.y;
        isDef = true;
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    void LateUpdate()
    {
        if(!inputField.isFocused)
        {
            switchView();
        }

        if(isDef)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            defaultPos();
            xrot = defPos.localRotation.x;
            yrot = defPos.localRotation.y;

            inputField.interactable = true;
            timeSlider.interactable = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            move();
            rotate();

            inputField.interactable = false;
            timeSlider.interactable = false;
        }
    }

    void move()
    {
        float hormov = Input.GetAxis("Horizontal") * speedmov * Time.deltaTime;
        float vermov = Input.GetAxis("Vertical") * speedmov * Time.deltaTime;

        Vector3 dir = transform.forward * vermov + transform.right * hormov;
        transform.Translate(dir, Space.World);
        Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x, minPos.position.x, maxPos.position.x), Mathf.Clamp(transform.position.y, minPos.position.y, maxPos.position.y), Mathf.Clamp(transform.position.z, minPos.position.z, maxPos.position.z));
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }

    void rotate()
    {
        float horrot = Input.GetAxis("Mouse X") * speedrot * Time.deltaTime;
        float verrot = Input.GetAxis("Mouse Y") * speedrot * Time.deltaTime;

        xrot -= verrot;
        yrot += horrot;

        transform.localRotation = Quaternion.Euler(xrot, yrot, transform.localRotation.z);
        //transform.Rotate(new Vector3(verrot, horrot, 0));
    }

    void defaultPos()
    {
        transform.position = Vector3.Lerp(transform.position, defPos.position, smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.localRotation, defPos.localRotation, smoothSpeed);
    }

    void switchView()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isDef = !isDef;
            CameraPos cp = FindObjectOfType<CameraPos>();
            if(!cp.swt)
            {
                cp.swt = true;
            }
        }
    }
}
