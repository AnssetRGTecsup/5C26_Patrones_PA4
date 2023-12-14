using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public BulletSO[] bulletSO;
    public Image[] currentImage;
    public Slider[] slider;
    public Button[] button;
    private int currentIndex = 0;
    private int[] arrayIndex;
    private void Awake()
    {
        arrayIndex = new int[bulletSO.Length];
    }
    void Start()
    {
        currentIndex = 0;
        UpdateIndexArray();
        CurrentImage();
        SliderValue();
    }
    private void InsertionSort(int[] array, string name)
    {
        int tmp;
        for (int i = 1; i < array.Length; ++i)
        {
            tmp = array[i];
            int j = i - 1;
            while (j >= 0 && Compare(bulletSO[j], bulletSO[tmp], name))
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = tmp;
        }
    }
    private bool Compare(BulletSO a, BulletSO b, string name)
    {
        switch (name)
        {
            case "Daño":
                return a.damage < b.damage;
            case "Rango":
                return a.range < b.range;
            case "Velocidad":
                return a.speed < b.speed;
            default:
                return a.municion < b.municion;
        }
    }
    public void UpdateIndexArray()
    {
        for (int i = 0; i < bulletSO.Length; i++)
            arrayIndex[i] = i;
    }
    public void SliderValue()
    {
        slider[0].value = bulletSO[currentIndex].damage;
        slider[1].value = bulletSO[currentIndex].range;
        slider[2].value = bulletSO[currentIndex].speed;
        slider[3].value = bulletSO[currentIndex].municion;
    }
    private void CurrentImage()
    {
        currentImage[0].sprite = bulletSO[currentIndex].municionSprite;
        currentImage[1].sprite = GetBulletIndex(currentIndex - 1);
        currentImage[2].sprite = GetBulletIndex(currentIndex + 1);
    }

    private Sprite GetBulletIndex(int index)
    {
        if (index < 0) return bulletSO[3].municionSprite;
        else if (index > 3) return bulletSO[0].municionSprite;
        else return bulletSO[index].municionSprite;
    }
    public void PreviousBullet()
    {
        currentIndex = currentIndex != 0 ? currentIndex-1 : 3;
        CurrentImage();
        SliderValue();
    }
    public void NextBullet()
    {
        currentIndex = currentIndex != 3 ? currentIndex+1 : 0;
        CurrentImage();
        SliderValue();
    }
    public void SortedArray(string name)
    {
        InsertionSort(arrayIndex, name);
        for (int i = 1; i < arrayIndex.Length; ++i)
        {
            BulletSO tmp = bulletSO[i - 1];
            bulletSO[i - 1] = bulletSO[i];
            bulletSO[i] = tmp;
        }
        currentIndex = 0;
        CurrentImage();
        SliderValue();
    }
}