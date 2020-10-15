using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    public GameObject prefabs, go, wayPoints;
    private float seconds = 0;
    private int interval = 0;
    private int spawnTime = 0;

    private void Awake()
    {   
        wayPoints = GameObject.Find("Waypoints");
    }

    private void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 5f)
        {
            Spawn();
            seconds = 0f;
        }

    }

    private void Spawn()
    {

        go = Instantiate(prefabs, new Vector2(0, 0), Quaternion.identity) as GameObject;

        if (interval == spawnTime)
        {
            go.GetComponent<FollowThePath>().willBuy = true;
            interval = 0;
            spawnTime = Random.Range(1, 4);
        }
        interval++;
        go.GetComponent<SpriteRenderer>().sprite = RandomSprite(Random.Range(1,4), go);
        go.transform.parent = wayPoints.transform;
    }

    private Sprite RandomSprite(int val, GameObject go)
    {
        switch (val)
        {
            default: return null;
            case 1: go.GetComponent<Animator>().SetTrigger("girl_back"); go.GetComponent<FollowThePath>().Person = "Girl"; return ItemAssets.Instance.couple;
            case 2: go.GetComponent<Animator>().SetTrigger("thief_back"); go.GetComponent<FollowThePath>().Person = "Thief";  return ItemAssets.Instance.theif;
            case 3: go.GetComponent<Animator>().SetTrigger("pakyaw_back"); go.GetComponent<FollowThePath>().Person = "Pakyaw";  return ItemAssets.Instance.pakyaw;
        }

    }


}
