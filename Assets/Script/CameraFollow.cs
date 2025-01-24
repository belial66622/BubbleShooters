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
    Transform player;

    bool isSet = false;
    private void LateUpdate()
    {
        var position = followAt.position + new Vector3(0, 0, -15f);
        if (!isSet) return;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, dampSpeed);
    }

    public void SetFollowTarget(Transform followThis)
    { 
        followAt = followThis;
        player = followThis;
        isSet = true;
    }
}
