using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    public bool SonTetikleyici;
    public GameObject KameraKonum;
    void Start()
    {
        target_offset = transform.position - target.position;
        
    }
    private void LateUpdate()
    {
        
        if (!SonTetikleyici)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, KameraKonum.transform.position + target_offset, .015f);
        }


    }
    void Update()
    {
        
    }
}
