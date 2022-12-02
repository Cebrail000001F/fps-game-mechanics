using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] Weaponry;
    [SerializeField] private AudioSource sound;
    int QSerialNumber;
    int mauseSerialNumber;
    void Update()
    {
        KeyboardInput();
        WeaponChange2();
        WeaponChange3();
    }
    /// <summary>
    /// Rakamlar ile silah değiştirme
    /// </summary>
    /// <param name="keyboardSerialNumber"></param>
    void WeaponChange1(int keyboardSerialNumber)
    {
        WeaponPassive();
        QSerialNumber = keyboardSerialNumber;   //Q ve Sayı ile değitirmeyi paralele kullanmak
        mauseSerialNumber = keyboardSerialNumber;   //mause ve Sayı ile değitirmeyi paralele kullanmak
        Weaponry[keyboardSerialNumber].SetActive(true);
        Debug.Log(keyboardSerialNumber);
    }
    /// <summary>
    /// Kullanıcı Klavye Girdisi
    /// </summary>
    void KeyboardInput()
    {
        if (Input.GetKeyDown("1"))
        {
            WeaponChange1(0);
        }
        if (Input.GetKeyDown("2"))
        {
            WeaponChange1(1);
        }
        if (Input.GetKeyDown("3"))
        {
            WeaponChange1(2);
        }
        if (Input.GetKeyDown("4"))
        {
            WeaponChange1(3);
        }
    }
    /// <summary>
    /// Q ile silah değiştirme
    /// </summary>
    void WeaponChange2()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WeaponPassive();
            if (QSerialNumber == 3)
            {
                QSerialNumber = 0;
                Weaponry[QSerialNumber].SetActive(true);
            }
            else 
            {
                QSerialNumber++;
                Weaponry[QSerialNumber].SetActive(true);
            }
        }
    }
    /// <summary>
    /// Mause kontrol ile değiştirme
    /// </summary>
    void WeaponChange3()
    {
         if (Input.GetAxis("Mouse ScrollWheel") > 0f)
         {
            WeaponPassive();
            if (mauseSerialNumber == 3)
            {
                mauseSerialNumber = 0;
                Weaponry[mauseSerialNumber].SetActive(true);
            }
            else
            {
                mauseSerialNumber++;
                Weaponry[mauseSerialNumber].SetActive(true);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            WeaponPassive();
            if (mauseSerialNumber == 0)
            {
                mauseSerialNumber = 3;
                Weaponry[mauseSerialNumber].SetActive(true);
            }
            else
            {
                mauseSerialNumber--;
                Weaponry[mauseSerialNumber].SetActive(true);
            }
        }
    }
    /// <summary>
    /// aktif silahları pasif yap ve değiştirme sesi ekler
    /// </summary>
    private void WeaponPassive() 
    {
        sound.Play();
        foreach (var silah in Weaponry)
        {
            silah.SetActive(false);
        }
    }
}
