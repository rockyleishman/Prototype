using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform PlayerBody;

    [SerializeField] public float MouseSensitivity = 150.0f;
    [SerializeField][Range(0.0f, 89.999f)] public float UpperClamp = 75.0f;
    [SerializeField][Range(-89.999f, 0.0f)] public float LowerClamp = -75.0f;

    private float _XRotation;

    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
        {
            UpdateRotation();
        }
    }

    private void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        _XRotation -= mouseY;
        _XRotation = Mathf.Clamp(_XRotation, LowerClamp, UpperClamp);

        transform.localRotation = Quaternion.Euler(_XRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
