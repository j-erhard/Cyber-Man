using TMPro;
using UnityEngine;
// using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IAZombie : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    
    public int pv = 200;
    
    public CyberManController player;
    public float proximityThreshold = 10f;
    public Image progressBar;
    public Image progressBar2;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        Transform playerTransform = player.transform;
        
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= proximityThreshold)
        {
            if (player.pv <= 0)
            {
                SceneManager.LoadScene(2);
            }
            player.pv -= 0.08f;
            progressBar.rectTransform.sizeDelta = new Vector2(player.pv, progressBar.rectTransform.sizeDelta.y);
            float newXValue = -(200 - player.pv) / 2f;
            Vector3 newPosition = new Vector3(newXValue, progressBar.rectTransform.localPosition.y, progressBar.rectTransform.localPosition.z);
            progressBar.rectTransform.localPosition = newPosition;

        }
        
        distance = Vector3.Distance(transform.position, target.position);
        if (distance <= proximityThreshold)
        {
            if (player.nb_vie_target <= 0)
            {
                SceneManager.LoadScene(2);
            }
            player.nb_vie_target -= 0.02f;
            progressBar2.rectTransform.sizeDelta = new Vector2(player.nb_vie_target, progressBar2.rectTransform.sizeDelta.y);
            float newXValue = -(200 - player.nb_vie_target) / 2f;
            Vector3 newPosition = new Vector3(newXValue, progressBar2.rectTransform.localPosition.y, progressBar2.rectTransform.localPosition.z);
            progressBar2.rectTransform.localPosition = newPosition;

        }
    }
}