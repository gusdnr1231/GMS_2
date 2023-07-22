using System.Collections;
using UnityEngine;
using DG.Tweening;

public enum PetStates
{
    Idle,Moving,Defending,Healing
}

public enum Elements
{
    Water=0, Wind,Fire, Ground  ,Base
}

public class Pet : MonoBehaviour
{
    private readonly int _petposHash = Shader.PropertyToID("_PetPos");
    Vector4[] colors = { new Vector4(0,0,1,1), new Vector4(0, 0.4f, 0, 1), new Vector4(1, 0, 0, 1), new Vector4(139/255f, 69/255f, 19/255f, 1), new Vector4(1,1,0 ,1) };
    [SerializeField]
    private Material _mat;
    SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    GameObject defend;
    [SerializeField]
    float mousescroll=0;
    [SerializeField]
    float moveSpeed = 5;

    public float petHP = 8;
    GameObject player;
    
    public PetStates petState = PetStates.Idle;
    public Elements elements = Elements.Water;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector4 pos = transform.position;
        _mat.SetVector(_petposHash, pos);
        if(petState == PetStates.Idle && player != null)
            transform.position = player.transform.position;
        if(Input.GetMouseButtonDown(0) && petState!=PetStates.Healing&&petState!=PetStates.Moving) 
        {
            petState = PetStates.Moving;
            StartCoroutine(Moving());
        }
        if(Input.GetMouseButtonDown(1) && petState!=PetStates.Healing && petState!= PetStates.Moving) 
        {
            petState = PetStates.Defending;
            StartCoroutine(Defending());
        }
        mousescroll += Input.GetAxisRaw("Mouse ScrollWheel") * 10;
        mousescroll = mousescroll % 50;
        if (mousescroll < 0)
            mousescroll = 15;
        elements = (Elements)(mousescroll%5);
        _spriteRenderer.color = colors[(int)elements];
        if (petHP <= 0)
            StartCoroutine(Healing());
    }

    IEnumerator Moving()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir.z = 0;
        transform.DOMove(dir, Vector3.Distance(transform.position, dir) / moveSpeed);
        yield return new WaitForSeconds(Vector3.Distance(transform.position, dir) / moveSpeed);
        petState = PetStates.Idle;
    }

    IEnumerator Defending()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir.z = 0;
        if (Vector3.Distance(dir, transform.position) > 5)
            yield return 0;
        else
        {
            GameObject def = Instantiate(defend,transform.position,Quaternion.identity);
            def.transform.DOMove(dir, 1);
            def.transform.DOScale(def.transform.localScale * 1.5f, 1);
            def.GetComponent<SpriteRenderer>().color = colors[(int)elements];
            yield return new WaitForSeconds(4);
            Destroy(def);
            petState = PetStates.Idle;
        }
    }

    IEnumerator Healing()
    {
        petState = PetStates.Healing;
        transform.DOPause();
        yield return transform.DOMove(player.transform.position,Vector3.Distance(player.transform.position,transform.position) / (moveSpeed*2));
        yield return new WaitForSeconds(24);
        petHP = 8;
        petState = PetStates.Idle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            petHP--;
    }
}
