using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float Y_rot_Speed;
    public float turnSmooth;
    public float pivotSpeed;
    public float normalZ;
    public float normalY;
    public float normalX;
    public float minAngle;
    public float maxAngle;
}
