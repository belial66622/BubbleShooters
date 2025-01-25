using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameManager gameManager;

    List<Camera> cameras = new();

    List<GameObject> Enemy = new();

    bool IsTwoPlayer => cameras.Count == 2;

    bool flipflop = true;

    [SerializeField]
    float time = 5;

    [SerializeField]
    int maxenemy;
    void Start()
    {
        foreach (var cam in gameManager.CameraList)
        {
            if (cam.gameObject.activeInHierarchy)
            {
                cameras.Add(cam);
            }
        }
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        yield return null;
        float t = 0;

        while (true)
        {
            yield return null;
            t += Time.deltaTime / time;

            if (t < 1)
            {

            }

            else
            {
                t = 0;
                if (Enemy.Where(x => x.activeInHierarchy).Count() < maxenemy)
                {
                    if (Enemy.Count > 0)
                    {
                        {
                            var can = false;

                            foreach (var temp in Enemy)
                            {
                                if (!temp.activeInHierarchy)
                                {
                                    temp.SetActive(true);
                                    can = true;
                                    break;
                                }

                            }

                            if (!can)
                            {
                                var obj = Instantiate(enemy, GetPosition(), Quaternion.identity);
                                obj.GetComponent<FollowRandomTargetWithDynamicMovement>().SetGameManager(gameManager);
                                obj.SetActive(true);
                                Enemy.Add(obj);
                            }
                        }
                    }
                    else
                    {

                        var obj = Instantiate(enemy, GetPosition(), Quaternion.identity);
                        obj.GetComponent<FollowRandomTargetWithDynamicMovement>().SetGameManager(gameManager);
                        obj.SetActive(true);
                        Enemy.Add(obj);
                    }
                }
            }
        }
    }


    public Vector3 GetPosition()
    {
        Vector3 returnable = Vector3.zero;
        if (IsTwoPlayer)
        {
            if (flipflop)
            {
                returnable = RandomV(cameras[0].rect.xMin, cameras[0].rect.xMax, cameras[0].rect.yMin, cameras[0].rect.yMax);
            }
            else
            {
                returnable = RandomV(cameras[1].rect.xMin, cameras[1].rect.xMax, cameras[1].rect.yMin, cameras[1].rect.yMax);
            }
            flipflop = !flipflop;
        }
        else
        {
            returnable = RandomV(cameras[0].rect.xMin, cameras[0].rect.xMax, cameras[0].rect.yMin, cameras[0].rect.yMax);
        }
        return returnable;
    }

    public Vector3 RandomV(float xMin, float xMax, float yMin, float yMax)
    {
        Vector3 returnable = Vector3.zero;
        switch (Random.Range(0, 4))
        {
            case 0:
                returnable = new Vector3(Random.Range(xMin, xMax), yMax);
                break;
            case 1:
                returnable = new Vector3(Random.Range(xMin, xMax), yMin);
                break;
            case 2:
                returnable = new Vector3(xMin, Random.Range(yMin, yMax));
                break;
            case 3:
                returnable = new Vector3(xMax, Random.Range(yMin, yMax));
                break;
        }

        return returnable;
    }

}
