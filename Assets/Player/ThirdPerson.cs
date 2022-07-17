using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform camTrans;
    public Transform pivot;
    public Transform Character;
    public Transform mTransform;

    public CameraConfig cameraConfig;
    public bool leftPivot;
    public float delta;

    [HideInInspector] public float mouseX;
    [HideInInspector] public float mouseY;
    [HideInInspector] public float smoothX;
    [HideInInspector] public float smoothY;
    [HideInInspector] public float smoothXVelocity;
    [HideInInspector] public float smoothYVelocity;
    [HideInInspector] public float lookAngle;
    [HideInInspector] public float titleAngle;

    private void Update()
    {
        FixedTick();
    }

    private void FixedTick()
    {

        delta = Time.deltaTime;
        HandlePosition();
        HandleRotation();
        Vector3 targetPos = Vector3.Lerp(mTransform.position, Character.position, 1);
        mTransform.position = targetPos;

    }

    private void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = cameraConfig.normalZ;

        if (leftPivot)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPos = pivot.localPosition;
        newPivotPos.x = targetX;
        newPivotPos.y = targetY;

        Vector3 newCameraPos = camTrans.localPosition;
        newCameraPos.z = targetZ;

        float t = delta * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPos, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPos, t);
    }

    private void HandleRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (cameraConfig.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);
        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }

        lookAngle += smoothX * cameraConfig.Y_rot_Speed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titleAngle -= smoothY * cameraConfig.Y_rot_Speed;
        titleAngle = Mathf.Clamp(titleAngle, cameraConfig.minAngle, cameraConfig.maxAngle);
        pivot.localRotation = Quaternion.Euler(titleAngle, 0, 0);
        transform.rotation = targetRot;
    }
}
