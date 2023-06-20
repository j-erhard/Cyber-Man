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
        if (Input.GetMouseButtonDown(0))
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
        
            Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
            Debug.Log(hit.collider.gameObject.layer + " nico jte dbz " + LayerMask.NameToLayer(layerToDestroy.ToString()));
            // Vérifier si l'objet doit être détruit en fonction du layer
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "Zombie")
            {
                Destroy(hit.collider.gameObject);
            }

            var boo = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
            boo.transform.up = hit.normal;
        }
    }


}
