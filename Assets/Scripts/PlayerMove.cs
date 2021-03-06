using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x, z;
    private float velocitySpeed;

    private CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos, currPos;


    public static bool canMove = true;
    public static bool moving = false;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate velocity speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //Get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;


        if(Input.GetMouseButtonDown(0))
        {
            if(canMove)
            {  
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit))
                {
                    nav.destination = hit.point;
                }
            }
        }

        if(velocitySpeed != 0)
        {   
            anim.SetBool("sprinting", true);
            moving = true;
        }
        if(velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
            moving = false;
        }


        if(Input.GetMouseButton(1))
        {
            if(pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }

    }
}
