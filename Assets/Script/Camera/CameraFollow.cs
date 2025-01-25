using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform followAt;

    [SerializeField] 
    float dampSpeed =0.25f;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    public Vector3 offset = Vector3.zero;


    bool isSet = false;
    private void LateUpdate()
    {
        var position = followAt.position + offset;
        if (!isSet) return;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, dampSpeed);
    }

    public void SetFollowTarget(Transform followThis)
    { 
        followAt = followThis;
        isSet = true;
    }
}
