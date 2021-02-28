using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
 public GameObject scoreobject;
   
    private void Start()
    {
        Instantiate(scoreobject,transform.position, Quaternion.identity);
    }
    
}
