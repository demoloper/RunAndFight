using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alt_karakter : MonoBehaviour
{
   
    NavMeshAgent _Navmesh;
    public  GameManager _GameManeger;
    public GameObject Target;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
       
    }
    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }
    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .25f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ignelikutu"))
        {
            _GameManeger.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Testere"))
        {
            _GameManeger.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Pervane_igne"))
        {   
            _GameManeger.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Balyoz"))
        {
            _GameManeger.YokOlmaEfektiOlustur(PozisyonVer(), true);  
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Dusman"))
        {
            _GameManeger.YokOlmaEfektiOlustur(PozisyonVer(), false,false);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _GameManeger.Karakterler.Add(other.gameObject);
            
        }
    }
    void Update()
    {
        
    }

}
