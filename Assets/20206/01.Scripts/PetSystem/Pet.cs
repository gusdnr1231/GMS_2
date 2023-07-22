using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum PetStates
{
    Idle,Moving,Defending,Healing
}

public enum Elements
{
    Water=0, Wind,Fire, Ground
}

public class Pet : MonoBehaviour
{
    [SerializeField]
    List<Material> _materials;
    Vector4[] colors = { new Vector4(0,0,1,1), new Vector4(0, 0.4f, 0, 0.2f), new Vector4(1, 0, 0, 1), new Vector4(139/255f, 69/255f, 19/255f, 1) };
    SpriteRenderer _spriteRenderer;
    Camera _cam;
    [SerializeField]
    float mousescroll=0;
    
    public PetStates petState = PetStates.Idle;
    public Elements elements = Elements.Water;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && petState!=PetStates.Healing) 
        {
            Moving();
        }
        if(Input.GetMouseButtonDown(1) && petState!=PetStates.Healing) 
        {
            Defending();
        }
        if((int)elements == 0 && (Input.GetAxisRaw("Mouse ScrollWheel") < 0))
            elements = Elements.Ground;
        else
            elements = (Elements)((Input.GetAxisRaw("Mouse ScrollWheel") * 10 + (int)elements)%4);
        _spriteRenderer.color = colors[(int)elements];
    }

    void Moving()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            
        }
    }

    void Defending()
    {

    }
}
