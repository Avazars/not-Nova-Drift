using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundScript : MonoBehaviour
{

    [SerializeField] private GameObject target;
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0,0,1), 20 * Time.deltaTime);
    }
}
