using UnityEngine;

public class CyberManController : MonoBehaviour
{
    public float Speed = 1.5f;
    public Vector3 DirectionDeplacement = Vector3.zero;
    public CharacterController Player;
    public float Sensi = 2f;
    private float cameraRotation = 0f;
    public float Jump = 2f;
    public float Gravite = 10f;
    private Animator Anim;
    private PauseMenuInGame _pauseMenuInGame;
    public float nb_vie_target = 200;
    public float pv = 200;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        _pauseMenuInGame = FindObjectOfType<PauseMenuInGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseMenuInGame.isPaused)
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
        }
        else
        {
            Anim.SetBool("ClickLeft", false);
        }
    }
}
