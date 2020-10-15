using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FollowThePath : MonoBehaviour
{
    public string Person;
    public Transform[] waypoints;

    public float moveSpeed = 2f;

    private int waypointIndex = 0;

    public bool willBuy = false;
    public bool isWaiting;
    public float seconds;

    public bool oneTimeAnim;
    public bool shortCut;
    public bool shortCut2;
    public bool deym;

    Animator anim;

    void Start()
    {
        waypoints = gameObject.transform.parent.gameObject.GetComponentsInChildren<Transform>();
        transform.position = GameObject.Find("Waypoints").gameObject.transform.Find("Waypoint").transform.position;
        anim = GetComponent<Animator>();
        waypointIndex++;
        seconds = 5f;
        isWaiting = true;
        oneTimeAnim = false;
        shortCut2 = false;
        shortCut = false;
        deym = false;
    }

    void Update()
    {

        // Move Enemy

        if (seconds <= 3f)
        {
            seconds += Time.deltaTime;
            deym = true;
        }
        else
        {
            Move();

        }
    }

     void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {

            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            if (transform.position.x == waypoints[waypointIndex].transform.position.x && transform.position.y == waypoints[waypointIndex].transform.position.y)
            {

                switch (waypointIndex)
                {
                    case 1: waypointIndex++; break;
                    case 2:
                        if (Random.Range(0, 2) == 1) {
                            waypointIndex = 9;
                        } else { Right(); waypointIndex++; }; 
                        break;
                    case 3: waypointIndex++; break;
                    case 4:
                        if (Random.Range(0, 2) == 1)
                        {
                            waypointIndex = 8;
                            Backward();
                        }
                        else
                        {
                            Right(); waypointIndex++;
                        }
                        break;
                    case 5: Right(); waypointIndex++; break;
                    case 6: Left(); waypointIndex++; break;
                    case 7: Left(); waypointIndex++; break;
                    case 8: Left(); waypointIndex++; break;
                    case 9: Left();  waypointIndex++; break;
                    case 10: Left(); waypointIndex++;  break;
                    case 11: Up(); waypointIndex++;   break;
                    case 12: Right(); waypointIndex++; break;
                    case 13: Up(); waypointIndex++; break;
                    case 14: Destroy(gameObject); break;
                }

            }

            if (deym)
            {
                Right();
                deym = false;
            }



            if (waypointIndex == 3 && willBuy)
            {
                waypointIndex += 1;
            }
            else if (waypointIndex == 4 && !willBuy){
                if (isWaiting)
                {
                    Idle();
                    seconds = 0f;
                    isWaiting = false;
                    switch (Person)
                    {
                        case "Pakyaw":
                            PlayerNecessity.Instance.GetInventory().buyItem(Random.Range(10,30));
                            break;
                        case "Girl":
                            PlayerNecessity.Instance.GetInventory().buyItem(Random.Range(0, 10));
                            break;
                        case "Thief":
                            PlayerNecessity.Instance.GetInventory().buyItem(Random.Range(-5, 0));
                            break;
                    }
                }
            }



        }




    }

    public void Up()
    {
        switch (Person)
        {
            case "Girl": anim.SetTrigger("girl_run"); break;
            case "Pakyaw": anim.SetTrigger("pakyaw_run"); break;
            case "Thief":anim.SetTrigger("thief_run"); break;
        }

    }
    public void Backward()
    {
        switch (Person)
        {
            case "Girl": anim.SetTrigger("girl_back"); break;
            case "Pakyaw": anim.SetTrigger("pakyaw_back"); break;
            case "Thief": anim.SetTrigger("thief_back"); break;
        }

    }
    public void Right()
    {
        switch (Person)
        {
            case "Girl": anim.SetTrigger("girl_right"); break;
            case "Pakyaw": anim.SetTrigger("pakyaw_right"); break;
            case "Thief": anim.SetTrigger("thief_rigt"); break;
        }

    }

    private void Left()
    {
        switch (Person)
        {
            case "Girl": anim.SetTrigger("girl_left"); break;
            case "Pakyaw": anim.SetTrigger("pakyaw_left"); break;
            case "Thief": anim.SetTrigger("thief_left"); break;
        }

    }

    public void Idle()
    {
        switch (Person)
        {
            case "Girl": anim.SetTrigger("girl"); break;
            case "Pakyaw": anim.SetTrigger("pakyaw"); break;
            case "Thief": anim.SetTrigger("thief_idle"); break;
        }

    }

}