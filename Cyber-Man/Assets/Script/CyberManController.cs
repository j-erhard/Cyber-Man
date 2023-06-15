using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberManController : MonoBehaviour
{
    public float Speed = 2f;
    public Vector3 DirectionDeplacement = Vector3.zero;
    public CharacterController Player;
    public float Sensi = 2f;
    private float cameraRotation = 0f;
    public float Jump = 2f;
    public float Gravite = 10f;
    private Animator Anim;
    private AffichageSouris _affichageSouris;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        _affichageSouris = FindObjectOfType<AffichageSouris>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_affichageSouris.cursorVisible)
        {
            return;
        }
        // MOVE
        
        DirectionDeplacement.x = Input.GetAxis("Horizontal");
        DirectionDeplacement.z = Input.GetAxis("Vertical");
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
        Player.Move(DirectionDeplacement * Time.deltaTime * Speed);

        // ROTATE
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * Sensi, 0);

        // CAMERA ROTATION
        float mouseY = Input.GetAxisRaw("Mouse Y") * Sensi;
        cameraRotation -= mouseY;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded)
        {
            DirectionDeplacement.y = Jump;
            Anim.SetBool("Jump", true);
        }
        if (!Player.isGrounded)
        {
            DirectionDeplacement.y -= Gravite * Time.deltaTime;
            Anim.SetBool("Jump", false);
        }

        // ANIMATION
        if (DirectionDeplacement.x != 0 || DirectionDeplacement.z != 0)
        {
            Anim.SetBool("Walk", true);
        }
        else
        {
            Anim.SetBool("Walk", false);
        }

        // SHOOT
        if (Input.GetMouseButton(0))
        {
            Anim.SetBool("ClickLeft", true);
            // Shoot();
        }
        else
        {
            Anim.SetBool("ClickLeft", false);
        }
    }

    // private void Shoot()
    // {
    //     RaycastHit hit;
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //
    //     if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
    //     {
    //         Destroy(hit.collider.gameObject);
    //         var boo = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
    //         boo.transform.up = hit.normal;
    //     }
    // }

}
