using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpaceGravity : MonoBehaviour
{
    public float AttractionForce;
    public GameObject debug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("gravity"))
        {
            float mass = collision.gameObject.GetComponent<MassInfo>().mass;
            Vector2 distance = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y);
            float GF = AttractionForce * mass / distance.magnitude;
            GetComponent<Rigidbody2D>().velocity -= distance * GF * Time.deltaTime;
        }
    }
}
