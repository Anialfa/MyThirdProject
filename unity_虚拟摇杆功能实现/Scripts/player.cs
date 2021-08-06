using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Joystick mJoystick = new Joystick();
    float mMoveSpeed = 2f;


    void Start()
    {
        mJoystick = GameObject.Find("Canvas/Image1").GetComponent<Joystick>();
        mJoystick.JoystickMoveHandle = JoystickHandle;
        mJoystick.JoystickEndHandle = JoystickEndHandle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JoystickHandle(RectTransform content)
    {
        transform.eulerAngles = new Vector3(0, -content.eulerAngles.z, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * mMoveSpeed);
    }
    public void JoystickEndHandle(RectTransform content)
    {

    }
}
