using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
    }
}
