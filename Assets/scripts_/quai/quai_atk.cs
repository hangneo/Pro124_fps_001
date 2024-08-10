using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai_atk : MonoBehaviour
{
    [SerializeField] GameObject bullet_;
    [SerializeField] Transform fire_point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fire()
    {
        Instantiate(bullet_ , fire_point.position, fire_point.rotation);
    }
}
