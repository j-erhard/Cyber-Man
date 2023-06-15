using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CyberLaser : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask layerToDestroy;
    
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet doit être détruit en fonction du layer
            Debug.Log(hit.collider.gameObject.layer.ToString());
            if (hit.collider.gameObject.layer == layerToDestroy)
            {
                Destroy(hit.collider.gameObject);
                return; // Sortir de la méthode après la destruction de l'objet
            }

            var boo = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
            boo.transform.up = hit.normal;
        }
    }


}
