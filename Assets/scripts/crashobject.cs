using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashobject : MonoBehaviour
{
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 70);
    }
}
