using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CyberLaser : MonoBehaviour
{
    private LineRenderer lr;
    public Transform startPoint;
    public GameObject explosionPrefab;
    public float scaleExplo = 0.1f;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 5000);
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        RaycastHit hit;
    
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Destroy(hit.collider.gameObject);
            var boo = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
            boo.transform.up = hit.normal;
            boo.transform.localScale = new Vector3(scaleExplo, scaleExplo, scaleExplo);
        }
    }
}
