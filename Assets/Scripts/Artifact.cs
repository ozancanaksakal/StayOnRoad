using UnityEngine;

public class Artifact : MonoBehaviour
{
    public float rotationSpeed = 5;
    private GameManager gameManager;

    public int minScore, maxScore;

    public ParticleSystem affect;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //affect.transform.position = transform.position;
    }
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            affect.transform.position= transform.position;
            affect.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject,0.5f);
        }
    }
}
