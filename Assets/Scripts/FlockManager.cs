using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject botPrefab;
    public int numBots = 10;
    public GameObject[] allBots;
    public Vector3 runLimits = new Vector3(2, 2, 2);
    public Vector3 goalPos = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Bot Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)] 
    public float neighbourDistance;
    [Range(1.0f, 5.0f)] 
    public float rotationSpeed;
    void Start()
    {
        allBots = new GameObject[numBots];
        for (int i = 0; i < numBots; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-runLimits.x, runLimits.x),
                Random.Range(-runLimits.y, runLimits.y),
                Random.Range(-runLimits.z, runLimits.z));
            allBots[i] = Instantiate(botPrefab, pos, Quaternion.identity);
        }
        goalPos = this.transform.position;
    }

    private void Awake()
    {
        FM = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {

            goalPos = this.transform.position + new Vector3(
                Random.Range(-runLimits.x, runLimits.x),
                Random.Range(-runLimits.y, runLimits.y),
                Random.Range(-runLimits.z, runLimits.z));
        }
    }
}
