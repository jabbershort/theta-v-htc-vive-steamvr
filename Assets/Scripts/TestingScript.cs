using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this script is starting");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("this script was updated at "+System.DateTime.Now.ToString());
    }
}
