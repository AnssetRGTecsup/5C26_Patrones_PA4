using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexBalasEnemy : MonoBehaviour
{
    protected Rigidbody2D movimiento;
    protected float x = -1f;
    protected float y = 0;
    public float velocidad;
    private void Awake()
    {
        movimiento = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        movimiento.velocity = new Vector2(x, y) * velocidad * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimiteBala")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<VidaPlayer>().TomarDaño();
            Destroy(gameObject);
        }
    }
}
