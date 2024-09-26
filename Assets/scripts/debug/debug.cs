using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debug : MonoBehaviour
{
    public GameObject Player;
    public GameObject playervectortext;
    public GameObject playerrotationtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playervectortext.GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Rigidbody2D>().velocity.magnitude.ToString();
        playerrotationtext.GetComponent<TextMeshProUGUI>().text = Player.transform.eulerAngles.z.ToString();
    }
}
