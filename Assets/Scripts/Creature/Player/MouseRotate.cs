using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;


[System.Serializable]
public class MouseRotate : MonoBehaviour
{
    public float SensitivityX = 2.0f;
    public float SensitivityY = 2.0f;
    public bool clampVR = true;
    public float minimumX = -70.0f;
    public float maximumX = 70.0f;
    public bool smooth = true;
    public float smoothTime = 5.0f;
    public bool lockCursor = false;
    
    private Quaternion characterTargetRotate;
    private Quaternion cameraTargetRotate;
    private bool cursorIsLocked = true;

    public void Init(Transform character, Transform camera)
    {
        characterTargetRotate = character.localRotation;
        cameraTargetRotate = camera.localRotation;
    }

    public void LookRotation(Transform character, Transform camera)
    {
        float rotateY = Input.GetAxis("Mouse X") * SensitivityX;
        float rotateX = Input.GetAxis("Mouse Y") * SensitivityY;

        characterTargetRotate *= Quaternion.Euler(0f, rotateY, 0f);
        cameraTargetRotate *= Quaternion.Euler(-rotateX, 0f, 0f);

        if (clampVR)
            cameraTargetRotate = ClampRotateX(cameraTargetRotate);

        if(smooth)
        {
            character.localRotation = Quaternion.Slerp(character.localRotation, characterTargetRotate, smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp(camera.localRotation, cameraTargetRotate, smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = characterTargetRotate;
            camera.localRotation = cameraTargetRotate;
        }
    }

    public void SetCursorLock(bool value)
    {
        //lockCursor = value;
        //if(!lockCursor)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
    }

    public void UpdateCursorLock()
    {
        //if (lockCursor)
        //    InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIsLocked = true;
        }

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private Quaternion ClampRotateX(Quaternion quat)
    {
        quat.x /= quat.w;
        quat.y /= quat.w;
        quat.z /= quat.w;
        quat.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(quat.x);
        angleX = Mathf.Clamp(angleX, minimumX, maximumX);
        quat.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return quat;
    }
}
