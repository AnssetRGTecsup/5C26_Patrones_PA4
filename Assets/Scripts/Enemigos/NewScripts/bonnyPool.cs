using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonnyPool : MonoBehaviour
{

    public List<GameObject> listaConejos;

    [SerializeField] GameObject conejoTipo1;
    [SerializeField] GameObject conejoTipo2;

    [SerializeField] Vector3 posInicial;
    int rand;


    private void Awake()
    {
        listaConejos = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject nuevoConejo = Instantiate(conejoTipo1, posInicial, conejoTipo1.transform.rotation);
            nuevoConejo.SetActive(false);
            listaConejos.Add(nuevoConejo);

            nuevoConejo.GetComponent<VidaEnemigo>().objectPooling = this;
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        mandarConejo();
    }

    public void mandarConejo()
    {
        if (listaConejos.Count > 0)
        {
            //  posInicial = guardador;
            
            //float posR = Random.Range(-1.5f, 1.5f);
            //posInicial.y += posR;
            listaConejos[0].transform.position = posInicial;
            listaConejos[0].SetActive(true);
            listaConejos.RemoveAt(0);
        }
        
        rand = Random.Range(1, 4);
        Debug.Log("cantida de conejos en Lista:" + listaConejos.Count);
        Invoke("mandarConejo", rand);
    }

    public void devolverEnemy(GameObject conejo)
    {
        
        listaConejos.Add(conejo);
        conejo.SetActive(false);
    }

}

