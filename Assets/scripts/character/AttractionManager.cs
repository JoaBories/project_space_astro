using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionManager : MonoBehaviour
{
    public GameObject player;
    bool isInGravity = false;
    [SerializeField] List<GameObject> gravityList = new List<GameObject>();
    Vector2 velocity;
    public int futurNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position;
        velocity = player.GetComponent<Rigidbody2D>().velocity;
        for (int i = 0; i < futurNumber; i++)
        {
            updatepos();
        }

    }
    void updatepos()
    {
        transform.position = transform.position + (new Vector3(velocity.x, velocity.y, 0)) * Time.fixedDeltaTime;
        if (isInGravity)
        {
            float attractionForce = player.GetComponent<SpaceGravity>().AttractionForce;
            foreach (GameObject gravity in gravityList)
            {
                float mass = gravity.gameObject.GetComponent<MassInfo>().mass;
                Vector2 distance = new Vector2(transform.position.x - gravity.transform.position.x, transform.position.y - gravity.transform.position.y);
                float GF = attractionForce * mass / distance.magnitude;
                velocity -= distance * GF * Time.fixedDeltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gravity"))
        {
            isInGravity = true;
            gravityList.Add(collision.gameObject);
            Debug.Log("entrée");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("gravity"))
        {
            gravityList.Remove(collision.gameObject);
            if (gravityList.Count == 0)
            {
                isInGravity = false;
            }
        }
    }
}
