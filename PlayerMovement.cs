using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public GameObject interactIcon;
    public Rigidbody2D rb;
    public Animator anim;

    private bool isWalking;
    private bool Active; //Stele
    private Vector2 moveDirection;
    Collider2D coll;

    private Vector2 boxSize = new Vector2(3f, 3f);

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        interactIcon.SetActive(false);
    }
    void Update()
    {
        InputProcess();
    }

    void FixedUpdate()
    {
        Move();
    }
    void InputProcess()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
 
        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
        if (Input.GetKeyDown(KeyCode.F) && !Active)
        {
            Activate();
        }
        if(Active && Input.GetKeyDown(KeyCode.F))
        {
            Active = false;
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        anim.SetBool("isWalking", true);
        if(moveDirection.x == 0 && moveDirection.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }
    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return; //return pois, jos haluaa interaktoida kaikkien lähellä olevien juttujen kans 
                }
            }
        }
    }
    private void Activate()
    {
        Active = true;
        coll.enabled = !coll.enabled;
    }
    
}
