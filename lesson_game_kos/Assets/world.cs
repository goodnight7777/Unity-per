using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : MonoBehaviour
{

    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Vdist = gameObject.transform.position- camera.transform.position;
        Vector3 Vdir = Vdist.normalized;
        float Len = Vdist.magnitude;
        float M_p = GetComponent<Rigidbody>().mass;
        float M_k = camera.GetComponent<Rigidbody>().mass;
        const float G = 1;
        Vector3 Vf = Vdir * G * M_p * M_k / (Len * Len);
        camera.GetComponent<Rigidbody>().AddForce(Vf);
    }
}
