using UnityEngine;
using UnityEngine.AI;

public class AgentNavigation : MonoBehaviour
{
    float speed;

    //[SerializeField]
    //private Vector3 _desiredDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GetComponent<NavMeshAgent>().destination = _desiredDestination;
        if (FlockManager.FM == null)
        {
            Debug.LogError("FlockManager.FM is null! Make sure FlockManager is in the scene.");
            enabled = false;
            return;
        }
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {

            speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
        }
        if (Random.Range(0, 100) < 10)
        {
            ApplyRules();
        }
        ApplyRules();
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void ApplyRules()
    {

        GameObject[] gos;
        gos = FlockManager.FM.allBots;

        Vector3 vCentre = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;

        float gSpeed = 0.01f;
        float mDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {

            if (go != this.gameObject)
            {

                mDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (mDistance <= FlockManager.FM.neighbourDistance)
                {

                    vCentre += go.transform.position;
                    groupSize++;

                    if (mDistance < 1.0f)
                    {

                        vAvoid = vAvoid + (this.transform.position - go.transform.position);
                    }

                    AgentNavigation anotherFlock = go.GetComponent<AgentNavigation>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0)
        {

            vCentre = vCentre / groupSize; // + (FlockManager.FM.goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            if (speed > FlockManager.FM.maxSpeed)
            {

                speed = FlockManager.FM.maxSpeed;
            }

            Vector3 direction = (vCentre + vAvoid) - transform.position;
            if (direction != Vector3.zero)
            {

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    FlockManager.FM.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
