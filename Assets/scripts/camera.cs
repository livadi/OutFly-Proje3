
using UnityEngine;

public class camera : MonoBehaviour
{

    private Vector3 offset;
  public GameObject player;
   
    private float smoothS = 0.3f;
    void Start()
    {
        offset = transform.position - player.transform.position;
    

    }

    void FixedUpdate()
    {
        
        Vector3 newPos = player.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothS);
      
    }
}
