using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    float TimeToPick = 1;

    Collider2D colliders;
    public int XP=0;

    private void Awake()
    {
        colliders = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        colliders.enabled = true;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Picked(Transform player)
    {
        colliders.enabled = false;
        StartCoroutine(ItemPick(player));
    }

    IEnumerator ItemPick(Transform player)
    {
        var movement = player.gameObject.GetComponent<Movement>().playerControl;
        float time = 0;
        while (time < 1)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, player.position, EaseInCirc(time));
            time += Time.deltaTime/ TimeToPick;
        }
        EventsSystem.OnGetXp(XP, movement);
        yield return null;
        gameObject.SetActive(false);
    }

    public float EaseinOutBack(float time)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return time < 0.5
          ? (Mathf.Pow(2 * time, 2) * ((c2 + 1) * 2 * time - c2)) / 2
          : (Mathf.Pow(2 * time - 2, 2) * ((c2 + 1) * (time * 2 - 2) + c2) + 2) / 2;
    }

    public float EaseInCirc(float time)
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(time, 2));
    }

    public float EaseOutCubic(float time)
    {
        return 1 - Mathf.Pow(1 - time, 3);
    }
}
