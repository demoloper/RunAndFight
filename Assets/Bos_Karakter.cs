using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bos_Karakter : MonoBehaviour
{
    public NavMeshAgent _Navmesh;
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakMaterial;
    public Animator _Animator;
    public GameObject Target;
    public GameManager _GameManager;
    bool Temasvar;
    
    private void LateUpdate()
    {
        if (Temasvar)
        {
            _Navmesh.SetDestination(Target.transform.position);
        }
       
    } 
    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MatsveAnimasyon();
                Temasvar = true;
                GetComponent<AudioSource>() .Play();
            }
            

        }
        else if (other.CompareTag("ignelikutu"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Pervane_igne"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(), true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Dusman"))
        {
          
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(), false, false);
            gameObject.SetActive(false);
        }
    }
    void MatsveAnimasyon()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakMaterial;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldir", true);
        GameManager.AnlikKarakterSayisi++;
        gameObject.tag = "AltKarakterler";

    }
}
