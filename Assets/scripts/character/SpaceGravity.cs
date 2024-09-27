using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpaceGravity : MonoBehaviour
{
    public float AttractionForce;
    bool isInGravity = false;
    List<GameObject> gravityList = new List<GameObject>();
    public GameObject sunDebug;
    public GameObject planet1Debug;
    public GameObject planet2Debug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInGravity)
        {
            foreach (GameObject gravity in gravityList)
            {
                float mass = gravity.gameObject.GetComponent<MassInfo>().mass;
                float distanceSurface = gravity.transform.parent.localScale.x / 2;
                Vector2 distance = new Vector2(transform.position.x - gravity.transform.position.x, transform.position.y - gravity.transform.position.y);
                float GF = AttractionForce * mass / Mathf.Max(0.1f, distance.magnitude - distanceSurface);
                GetComponent<Rigidbody2D>().velocity -= distance.normalized * GF * Time.fixedDeltaTime;
                if (gravity.name == "gravitysun")
                {
                    sunDebug.SetActive(true);
                    sunDebug.GetComponent<TextMeshProUGUI>().text = "sun : " + (Mathf.Round(distance.magnitude) - 250) + "m \n" + (-(distance.normalized * GF * Time.fixedDeltaTime).magnitude) + "\n" + GF;
                }
                else if (gravity.name == "gravityplanet1")
                {
                    planet1Debug.SetActive(true);
                    planet1Debug.GetComponent<TextMeshProUGUI>().text = "planet1 : " + (Mathf.Round(distance.magnitude) - 15) + "m \n" + (-(distance.normalized * GF * Time.fixedDeltaTime).magnitude) + "\n" + GF;
                }
                else if (gravity.name == "gravityplanet2")
                {
                    planet2Debug.SetActive(true);
                    planet2Debug.GetComponent<TextMeshProUGUI>().text = "planet2 : " + (Mathf.Round(distance.magnitude) - 20) + "m \n" + (-(distance.normalized * GF * Time.fixedDeltaTime).magnitude) +"\n"+ GF;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gravity"))
        {
            isInGravity = true;
            gravityList.Add(collision.gameObject);
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
