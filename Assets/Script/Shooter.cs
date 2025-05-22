using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    public CandyMananger manager;
    AudioSource shotSound;

    private void Start()
    {
        shotSound = GetComponent<AudioSource>(); //cbi sd am thanh
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }
    void Shot()
    {
        // Neu so luong keo dc ban = 0 thi khong duoc ban nua
        if (manager.GetCandyAmount() <= 0)
        {
            return;
        }
        // Ban keo sau moi lan click chuot
        GameObject candy = Instantiate(SelectCandy(), GetInstantiatePosition(),Quaternion.identity);// Copy keo
        Rigidbody rb = candy.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotForce); //Them luc day huong ve phia trc
        rb.AddTorque(new Vector3(0,shotTorque,0));  //‚Ë‚¶‚ê
        // Xoa keo sau khi roi
        manager.ConsumeCandy();
        manager.DisplayCandyAmount();
        shotSound.Play(); // Bat am thanh ban
    }

    // Chon ngau nhien keo de ban ra
    GameObject SelectCandy()
    {
        int select = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[select];
    }
    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth/2);
        return transform.position + new Vector3(x, 0, 0);
    }
}
