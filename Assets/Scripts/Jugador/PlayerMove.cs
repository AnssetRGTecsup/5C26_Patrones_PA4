using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject target;

    public PlayerSO Player;
    public Rigidbody2D rb;
    public float direccion;
    private Animator animator;
    public AdministradorBalas disparo;

    public float range;
    public float radius;
    public LayerMask jumpLayer;

    private bool MirandoDerecha = true;
    public bool isGround = true;
 
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        direccion = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direccion * Player.velocidad, rb.velocity.y);
        GroundRayCast();

        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rb.AddForce(Vector2.up * Player.Fuerzasalto, ForceMode2D.Impulse);
        }

        AnimationControl();
    }

    private void FixedUpdate()
    {

        Mover(direccion * Time.fixedDeltaTime);
    }

    private void Mover(float mover)
    {
        if( mover > 0 && !MirandoDerecha) // 3 + MAX( If, Else)
        {
            Girar(); // 5
        }
        else if (mover < 0 && MirandoDerecha)
        {
            Girar(); // 5
        } // 3 + 5 = 8
    }
    //Tiempo asintotico O(1) es constante 

    private void Girar()
    {
        MirandoDerecha = !MirandoDerecha; // 2; 1 comparacion y 1 negacion 
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); // 3; 3 asignacion y 1 suma
        //2+3 = 5
    }
    //Tiempo asintotico O(1) es constante 

    private void AnimationControl()
    {
        if (direccion == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
            animator.SetBool("Shoot", false);
        }

        if (isGround)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Shoot", false);
        }

        animator.SetBool("Shoot", disparo.isFire);
    }

    public void GroundRayCast()
    {
        RaycastHit2D hitGround;
        hitGround = Physics2D.CircleCast(target.transform.position, radius, - target.transform.up, range, jumpLayer);
        Debug.DrawRay(target.transform.position, -target.transform.up * hitGround.distance, Color.red);

        if (hitGround.collider != null)
        {
            if (hitGround.distance <= 0.2f)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(target.transform.position, target.transform.position + -target.transform.up * 5);
        Gizmos.DrawWireSphere(target.transform.position + -target.transform.up * 5, radius);
    }*/
}
