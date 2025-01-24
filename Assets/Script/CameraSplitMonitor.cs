using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSplitMonitor : MonoBehaviour
{
    [SerializeField]
    List<Camera> _cameraList;

    [SerializeField]
    bool isUsingTransform;

    int cameraCount = 0;

    public void RegisterPlayer(Transform transform)
    {
        if (isUsingTransform)
        {
            _cameraList[cameraCount].gameObject.transform.parent = transform;
            _cameraList[cameraCount].gameObject.transform.localPosition = new Vector3(0, 0, -10f);
        }

        else
        {
            _cameraList[cameraCount].gameObject.transform.position = transform.position + new Vector3 (0,0,-15f);
            var cam =_cameraList[cameraCount].GetComponent<CameraFollow>();
            cam.SetFollowTarget(transform);
        }
        _cameraList[cameraCount].gameObject.SetActive(true);
        cameraCount++;
    }


    public void SetCamera()
    {
        if (cameraCount < 2)
        {
            return;
        }
        else
        {
            _cameraList[0].rect = new Rect(new Vector2(0, 0), new Vector2(0.499f, 1));
            _cameraList[1].rect = new Rect(new Vector2(.501f, 0), new Vector2(0.499f, 1));
        }
    }
}
