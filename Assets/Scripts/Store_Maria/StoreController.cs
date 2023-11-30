using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    [Header("CircularDoubleLinkedList")]

    public Sprite[] bulletArray;
    public Image[] currentImage;
    CircularDoubleLinkedList<int> circularDoubleLinkedList;

    [Header("Hashtable")]
    public Bullet[] bullet;
    Hashtable<Bullet> hashtable;

    public int currentIndex;
    public int[] arrayIndex;

    [Header("Sliders")]
    public Slider[] slider;

    void Awake()
    {
        circularDoubleLinkedList = new CircularDoubleLinkedList<int>();
        hashtable = new Hashtable<Bullet>();
    }
    void Start()
    {
        for (int i = 0; i < bullet.Length; ++i)
        {
            bullet[i].index = hashtable.Add(bullet[i]);
            arrayIndex[i] = bullet[i].index;
        }

        circularDoubleLinkedList.AddNodeAtStart(arrayIndex[0]);

        for (int i = 1; i < arrayIndex.Length; ++i)
        {
            circularDoubleLinkedList.AddNodeAtEnd(arrayIndex[i]);
        }

        currentIndex = circularDoubleLinkedList.GetNodeValueAtStart();
        CurrentImage();
        SliderValue();
    }
    void Update()
    {

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
                if (hashtable.GetKey(array[j]).damage < hashtable.GetKey(array[j + 1]).damage)
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
                if (hashtable.GetKey(array[mindId]).range < hashtable.GetKey(array[j]).range)
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

            while (j >= 0 && hashtable.GetKey(array[j]).speed < hashtable.GetKey(tmp).speed)
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

            while (j >= 0 && hashtable.GetKey(array[j]).municion < hashtable.GetKey(tmp).municion)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = tmp;
        }
    }
    public void SliderValue()
    {
        slider[0].value = hashtable.GetKey(currentIndex).damage;
        slider[1].value = hashtable.GetKey(currentIndex).range;
        slider[2].value = hashtable.GetKey(currentIndex).speed;
        slider[3].value = hashtable.GetKey(currentIndex).municion;
    }
    public void CurrentImage()
    {
        currentImage[0].sprite = hashtable.GetKey(currentIndex).municionSprite;
        currentImage[1].sprite = hashtable.GetKey(circularDoubleLinkedList.PrintPreviousNode(currentIndex)).municionSprite;
        currentImage[2].sprite = hashtable.GetKey(circularDoubleLinkedList.PrintNextNode(currentIndex)).municionSprite;
    }
    public void PreviousBullet()
    {
        currentIndex = circularDoubleLinkedList.PrintPreviousNode(currentIndex);
        CurrentImage();
        SliderValue();
        //Debug.Log("Anterior");
    }
    public void NextBullet()
    {
        currentIndex = circularDoubleLinkedList.PrintNextNode(currentIndex);
        CurrentImage();
        SliderValue();
        //Debug.Log("Siguiente");
    }
    public void SortedCircularList(string name)
    {
        if (name == "Daño")
        {
            BubbleSortEnchanced(arrayIndex);
        }
        if (name == "Rango")
        {
            SelectionSortEnchanced(arrayIndex);
        }
        if (name == "Velocidad")
        {
            InsertionSort(arrayIndex);
        }
        if (name == "Municion")
        {
            InsertionSortMunicion(arrayIndex);
        }

        for (int i = 0; i < arrayIndex.Length; ++i)
        {
            circularDoubleLinkedList.ModifyAtPosition(arrayIndex[i], i);
        }
        currentIndex = circularDoubleLinkedList.GetNodeValueAtStart();
        CurrentImage();
        SliderValue();
    }
}
