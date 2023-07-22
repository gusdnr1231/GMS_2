using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Hp : MonoBehaviour
{
    [SerializeField] Slider HpGage;
   
    void Start()
    {
    
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HpGage.value -= 0.2f;
        }
    }

    public void Damege()
    {
        HpGage.value -= 0.2f;
    }


}
