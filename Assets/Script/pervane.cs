using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pervane : MonoBehaviour
{
    public Animator _Animator;
    public float  Beklemesuresi;
    public BoxCollider _Ruzgar;
    public void AnimasyonDurum(string durum)
    {

        if (durum == "true") { 
            _Animator.SetBool("Calistir",true);
             _Ruzgar.enabled = true;
        }

        else { 
            _Animator.SetBool("Calistir",false);
        StartCoroutine(AnimasyonuTetikle());
        _Ruzgar.enabled = false;
        }
    }
    IEnumerator AnimasyonuTetikle()
    {
        yield return new WaitForSeconds(Beklemesuresi);
        AnimasyonDurum("true");
    }

}
