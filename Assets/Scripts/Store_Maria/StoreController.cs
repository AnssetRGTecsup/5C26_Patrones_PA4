using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public List<BulletSO> bulletSO;

    //[Header("CircularDoubleLinkedList")]

    //public Sprite[] bulletArray;
    public Image[] currentImage;
    //CircularDoubleLinkedList<int> circularDoubleLinkedList;

    //[Header("Hashtable")]
    //public Bullet[] bullet;
    ////Hashtable<Bullet> hashtable;

    public int currentIndex = 0;
    //public int[] arrayIndex;

    [Header("Sliders")]
    public Slider[] slider;

    void Awake()
    {
        //circularDoubleLinkedList = new CircularDoubleLinkedList<int>();
        //hashtable = new Hashtable<Bullet>();
    }
    void Start()
    {
        currentIndex = 0;
        CurrentImage();
        SliderValue();
    }

    void BubbleSortEnchanced(int[] array)
    {
        int tmp;
        bool isOrder;
        for (int i = 0; i < array.Length - 1; ++i)
        {
            isOrder = true;
            for (int j = 0; j < array.Length - i - 1; ++j)
            {
                if (bulletSO[j].damage < bulletSO[j + 1].damage)
                {
                    tmp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tmp;
                    isOrder = false;
                }
            }

            if (isOrder == true)
            {
                break;
            }
        }
    }

    void SelectionSortEnchanced(int[] array)
    {
        int tmp;
        int mindId;
        for (int i = 0; i < array.Length - 1; ++i)
        {
            mindId = i;
            for (int j = i + 1; j < array.Length; ++j)
            {
                if (bulletSO[mindId].range < bulletSO[j].range)
                {
                    mindId = j;
                }
            }

            if (mindId != i)
            {
                tmp = array[i];
                array[i] = array[mindId];
                array[mindId] = tmp;
            }
        }
    }
    void InsertionSort(int[] array)
    {
        int tmp;
        for (int i = 1; i < array.Length; ++i)
        {
            tmp = array[i];
            int j = i - 1;

            while (j >= 0 && bulletSO[j].speed < bulletSO[tmp].speed)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = tmp;
        }
    }

    void InsertionSortMunicion(int[] array)
    {
        int tmp;
        for (int i = 1; i < array.Length; ++i)
        {
            tmp = array[i];
            int j = i - 1;

            while (j >= 0 && bulletSO[j].municion < bulletSO[tmp].municion)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = tmp;
        }
    }
    public void SliderValue()
    {
        slider[0].value = bulletSO[currentIndex].damage;
        slider[1].value = bulletSO[currentIndex].range;
        slider[2].value = bulletSO[currentIndex].speed;
        slider[3].value = bulletSO[currentIndex].municion;
    }
    public void CurrentImage()
    {
        currentImage[0].sprite = bulletSO[currentIndex].municionSprite;
        //currentImage[1].sprite = hashtable.GetKey(circularDoubleLinkedList.PrintPreviousNode(currentIndex)).municionSprite;
        //currentImage[2].sprite = hashtable.GetKey(circularDoubleLinkedList.PrintNextNode(currentIndex)).municionSprite;
    }
    public void PreviousBullet()
    {
        currentIndex--;

        if (currentIndex < 0)
            currentIndex = 3;

        CurrentImage();
        SliderValue();
        //Debug.Log("Anterior");
    }
    public void NextBullet()
    {
        currentIndex++;

        if (currentIndex > 3)
            currentIndex = 0;

        CurrentImage();
        SliderValue();
        //Debug.Log("Siguiente");
    }
    //public void SortedCircularList(string name)
    //{
    //    if (name == "Daño")
    //    {
    //        BubbleSortEnchanced(arrayIndex);
    //    }
    //    if (name == "Rango")
    //    {
    //        SelectionSortEnchanced(arrayIndex);
    //    }
    //    if (name == "Velocidad")
    //    {
    //        InsertionSort(arrayIndex);
    //    }
    //    if (name == "Municion")
    //    {
    //        InsertionSortMunicion(arrayIndex);
    //    }

    //    for (int i = 0; i < arrayIndex.Length; ++i)
    //    {
    //        circularDoubleLinkedList.ModifyAtPosition(arrayIndex[i], i);
    //    }
    //    currentIndex = circularDoubleLinkedList.GetNodeValueAtStart();
    //    CurrentImage();
    //    SliderValue();
    //}
}
