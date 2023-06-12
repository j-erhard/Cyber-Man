using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    private Animator Anim;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(previousPosition);
        // ANIMATION
        if (previousPosition != transform.position)
        {
            Anim.SetBool("Walk", true);
        }
        else
        {
            Anim.SetBool("Walk", false);
        }

        previousPosition = transform.position;
    }
}