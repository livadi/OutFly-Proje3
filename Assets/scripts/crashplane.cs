using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashplane : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 5 * Time.deltaTime);
    }
}
