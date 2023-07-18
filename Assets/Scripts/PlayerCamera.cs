using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform PlayerBody;
    [SerializeField] public Transform CameraHeadTransform;
    [SerializeField] public Transform CameraTailTransform;

    [SerializeField] public float MouseSensitivity = 150.0f;
    [SerializeField][Range(0.0f, 89.999f)] public float UpperClamp = 75.0f;
    [SerializeField][Range(-89.999f, 0.0f)] public float LowerClamp = -75.0f;
    [SerializeField] [Range(0.0f, 10.0f)] public float GravityFlipTime = 0.5f;

    private float _xRotation;
    private float _gravityFlipTimer;

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

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, LowerClamp, UpperClamp);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    public void GravityFlip()
    {
        _gravityFlipTimer = 0.0f;

        //set camera to tail position & rotation
        this.transform.position = CameraTailTransform.position;
        this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, CameraTailTransform.eulerAngles.z));

        //run camera flipping coroutine
        StartCoroutine("OnGravityFlip");
    }

    private IEnumerator OnGravityFlip()
    {
        while (_gravityFlipTimer < GravityFlipTime)
        {
            _gravityFlipTimer += Time.deltaTime;

            this.transform.position = Vector3.Lerp(CameraTailTransform.position, CameraHeadTransform.position, _gravityFlipTimer / GravityFlipTime);
            this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Mathf.SmoothStep(CameraTailTransform.eulerAngles.z, CameraHeadTransform.eulerAngles.z, _gravityFlipTimer / GravityFlipTime)));

            yield return null;
        }

        //set camera to head position & rotation
        this.transform.position = CameraHeadTransform.position;
        this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, CameraHeadTransform.eulerAngles.z));
    }
}
