using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCanvas : MonoBehaviour
{
    public GameObject[] canvas;
    GameObject nombreCanvas;

    public void ActivarPanel(string nombre) // -> O(n) -> ASINTÓTICO
    {
        for (int i = 0; i < canvas.Length; i++) // -> 1 + n (1 + _ _ + 2)
        {
            if (canvas[i].name == nombre) // -> 2 + MAX (INTERNA IF)
            {
                canvas[i].SetActive(true); // -> 2
            } // 2 + 2 = 4

        } // -> 1 + n (1 + 4 + 2) = 1 + 7n
    }

    public void DesactivarPanel(string nombre) // -> O(n) -> ASINTÓTICO
    {
        for (int i = 0; i < canvas.Length; i++) // -> 1 + n (1 + _ _ + 2)
        {
            if (canvas[i].name == nombre) // -> 2 + MAX (INTERNA IF)
            {
                nombreCanvas = canvas[i]; // -> 2
                canvas[i].SetActive(false); // -> 2
            } // -> 2 + 2 + 2 = 6

        } // -> 1 + n (1 + 6 + 2) = 1 + 9n
    }
    public void RetrocederPanel()
    {
        nombreCanvas.SetActive(true);
    }
}
