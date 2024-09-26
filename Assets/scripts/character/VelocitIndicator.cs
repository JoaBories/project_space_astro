using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitIndicator : MonoBehaviour
{
    public GameObject player;

    float scale;
    float rotation;
    Vector2 VelocityVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //VelocityVector = player.GetComponent<Rigidbody2D>().velocity;
        //scale = VelocityVector.magnitude;
        //// vecteuri = (1, 0);
        //float scalarproduct = VelocityVector.x;
        //float cosdirection = VelocityVector.x / scale;
        //float direction = Mathf.Acos(cosdirection);
        //transform.rotation.SetEulerAngles(0, 0, direction);

        
    }
}
