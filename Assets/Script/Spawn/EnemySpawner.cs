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

    [SerializeField]
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
        cameras = new();
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
                                    temp.transform.position = GetPosition();
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
                returnable = RandomV(cameras[0]);
            }
            else
            {
                returnable = RandomV(cameras[1]);
            }
            flipflop = !flipflop;
        }
        else
        {
            returnable = RandomV(cameras[0]);
        }
        return returnable;
    }

    public Vector3 RandomV(Camera pos)
    {
        Vector3 returnable = Vector3.zero;

        returnable = new Vector3(pos.transform.position.x + Random.Range(-20, 20), pos.transform.position.x + Random.Range(-20, 20), 0);


        /*        switch (Random.Range(0, 4))
                {
                    case 0:
                        break;
                    case 1:
                        returnable = pos.ViewportToWorldPoint(new Vector3(.5f, 1, 0));
                        break;
                    case 2:
                        returnable = pos.ViewportToWorldPoint(new Vector3(0, .5f, 0));
                        break;
                    case 3:
                        returnable = pos.ViewportToWorldPoint(new Vector3(1, .5f, 0));
                        break;
    }*/
        return returnable;
    }


}

