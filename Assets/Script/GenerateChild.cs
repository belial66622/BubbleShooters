using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChild : MonoBehaviour
{
    [SerializeField]
    float timeToGenerate = 1;
    private void OnEnable()
    {
        StartCoroutine(GenerateBlade());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator GenerateBlade()
    {
        float t = 0;
        while (true)
        {
            yield return null;
            if (t < 1)
            {
                t += Time.deltaTime / timeToGenerate;
            }
            else
            {
                foreach (Transform child in transform)
                {
                    if (!child.gameObject.activeInHierarchy)
                    {
                        child.gameObject.SetActive(true);
                        break;
                    }
                }
                t = 0;
            }
        }
    }
}
