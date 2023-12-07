using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AdministradorBalas : MonoBehaviour
{
    public static AdministradorBalas instancia;

    [Header("DoubleLinkedList")]
    public Bullet[] bulletArray;
    public DoubleLinkedList<Bullet> doubleLinkedList;
    //public List<Bullet> doubleLinkedList;

    public Bullet currentBullet;

    [Header("Disparo de Arma")]
    public Transform pivot;

    public float fireRate;
    private float nextFire;

    public bool isFire = false;

    [Header("Municion Actual")]
    public Image currentMunicion;
    public TextMeshProUGUI currenttMunicionText;


    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }

        doubleLinkedList = new DoubleLinkedList<Bullet>();
    }
    void Start()
    {
        doubleLinkedList.AddNodeAtStart(bulletArray[0]);
        //doubleLinkedList.Add(bulletArray[0]);

        for (int i = 1; i < bulletArray.Length; ++i)
        {
            doubleLinkedList.AddNodeAtEnd(bulletArray[i]);
        }

        for (int i = 0; i < bulletArray.Length; ++i)
        {
            doubleLinkedList.GetNodeValueAtPosition(i).currentMunicion = doubleLinkedList.GetNodeValueAtPosition(i).municion;
        }

        currentBullet = doubleLinkedList.GetNodeValueAtStart();
        CurrentImage();
        //doubleLinkedList.PrintAllNodes();
    }
    void Update()
    {
        nextFire += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && nextFire > currentBullet.range && currentBullet.CurrentMunicion != 0)
        {
            isFire = true;
            nextFire = 0;
            Disparar();
        }
        else
        {
            isFire = false;
        }

        if (Input.GetKeyDown("e"))
        {
            NextBullet();
        }

        if (Input.GetKeyDown("q"))
        {
            PreviousBullet();
        }

        CurrentImage();
    }
    public void CurrentImage()
    {
        currentMunicion.sprite = currentBullet.municionSprite;
        currenttMunicionText.text = currentBullet.CurrentMunicion + "/" + currentBullet.municion;
    }
    public void PreviousBullet()
    {
        currentBullet = doubleLinkedList.PrintPreviousNode(currentBullet);
        //Debug.Log("Anterior");
    }
    public void NextBullet()
    {
        currentBullet = doubleLinkedList.PrintNextNode(currentBullet);
        //Debug.Log("Siguiente");
    }
    private void Disparar()
    {
        if (Time.timeScale == 1f)
        {
            AudioManager.instancia.SonidoDisparar();
        }
        currentBullet.CurrentMunicion--;
        Instantiate(currentBullet.gameObject, pivot.position, pivot.rotation);
    }
}
