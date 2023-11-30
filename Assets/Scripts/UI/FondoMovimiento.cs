using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _startposition;

    public float speed;
    private int xdirection = -1;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _startposition = transform.position;
    }
    void Update()
    {
        EscenaMove();
    }
    void EscenaMove() // -> O(1) -> ASINTÓTICO
    {
        _transform.position = new Vector2(
            _transform.position.x + xdirection * speed * Time.deltaTime,
            _transform.position.y
            ); // -> 6

        if (_transform.position.x < -18.9f) // -> 1 + MAX (INTERNA IF)
        {
            _transform.position = _startposition; // --> 1
        } // -> 1 + 1 = 2

        // -> 6 + 2 = 8
    }
}
