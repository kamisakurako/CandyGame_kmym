using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyMananger manager;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Neu hung trung keo roi thi xoa keo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);

            // Them keo vao neu keo roi
            manager.AddCandy(reward);
            manager.DisplayCandyAmount();
            if (effectPrefab != null)
            {
                Instantiate(effectPrefab,   // copy
                    other.transform.position,   // dat vi tri
                    Quaternion.Euler(effectRotation));      //dat toc do quay
            }
        }
    }
}
