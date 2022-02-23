using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject hedef;
    public Vector3 Vektorum = new Vector3(0, 5f, -7f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = hedef.transform.position + Vektorum;
    }
}
