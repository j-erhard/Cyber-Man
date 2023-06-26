using TMPro;
using UnityEngine;
// using UnityEngine.UIElements;
using UnityEngine.UI;


public class CyberLaser : MonoBehaviour
{
    public GameObject explosionPrefab;

    public TextMeshProUGUI  textMun;

    public float munition_act = 0;
    
    public Image progressBar;
    public float duration = 1f;
    private float timer = 0f;
    
    // AUDIO
    
    public AudioClip audioClip1;
    private AudioSource audioSource1;
    public AudioClip audioClip2;
    private AudioSource audioSource2;
    
    void Start()
    {
        progressBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;
        if (Input.GetMouseButtonDown(0) && !progressBar.gameObject.activeSelf)
        {
            if (munition_act < 12)
            {
                
                AudioSource.PlayClipAtPoint(audioClip1, transform.position);
                Shoot();
                munition_act += 1;
                
                textMun.SetText((12 - munition_act).ToString());
                if (munition_act < 6)
                    textMun.color = Color.white;
                else if (munition_act < 10)
                    textMun.color = Color.yellow;
                else if (munition_act < 12)
                    textMun.color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && !progressBar.gameObject.activeSelf && munition_act != 0)
        {
            AudioSource.PlayClipAtPoint(audioClip2, transform.position);
            StartProgressBar();
        }
        
        if (progressBar.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / duration);
            progressBar.fillAmount = progress;
            
            progressBar.rectTransform.sizeDelta = new Vector2(50 - timer * 50, progressBar.rectTransform.sizeDelta.y);

            if (progress >= 1f)
            {
                munition_act = 0;
                textMun.SetText("12");
                textMun.color = Color.white;
                progressBar.gameObject.SetActive(false);
            }
        }
    }

    public void StartProgressBar()
    {
        timer = 0f;
        progressBar.fillAmount = 0f;
        progressBar.gameObject.SetActive(true);
    }
    
    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
        
            // Vérifier si l'objet doit être détruit en fonction du layer
            if (hit.collider.gameObject.name == "head")
            {
                IAZombie iaZombie = hit.collider.gameObject.transform.parent.GetComponent<IAZombie>();
                Debug.Log(iaZombie.pv);
                iaZombie.pv -= 150;
                Debug.Log(iaZombie.pv);
                if (iaZombie.pv <= 0)
                {
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                }
            }
            if (hit.collider.gameObject.name == "body")
            {
                IAZombie iaZombie = hit.collider.gameObject.transform.parent.GetComponent<IAZombie>();
                Debug.Log(iaZombie.pv);
                iaZombie.pv -= 50;
                Debug.Log(iaZombie.pv);
                if (iaZombie.pv <= 0)
                {
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                }
            }

            var boo = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
            boo.transform.up = hit.normal;
        }
    }


}
