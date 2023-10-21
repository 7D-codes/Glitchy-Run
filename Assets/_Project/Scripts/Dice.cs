using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField]
    GameHandler GH;
    private Rigidbody rb;
    private bool canDetectFace = false;
    private bool Finishedrolling = false;

    public Collider[] diceFaceColliders;

    public float velocityThreshold = 0.01f;

    public float minDistanceThreshold = 0.1f;

    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
        GH = GameObject.Find("GH").GetComponent<GameHandler>();
        rb.angularVelocity = Random.insideUnitSphere * 10f;
    }

    private void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, initialPosition);

        if (!canDetectFace && distanceMoved >= minDistanceThreshold)
        {
            canDetectFace = true; 
        }

        if (!Finishedrolling && canDetectFace && rb.velocity.magnitude < velocityThreshold)
        {
            Vector3 worldDown = -Vector3.up;

            Collider closestFaceCollider = null;
            float minDistance = float.MaxValue;

            foreach (var faceCollider in diceFaceColliders)
            {
                Vector3 centerToCollider = faceCollider.transform.position - transform.position;
                float distance = Vector3.Dot(centerToCollider, worldDown);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestFaceCollider = faceCollider;
                }
            }

            if (closestFaceCollider != null)
            {
                Debug.Log("The face facing up is " + closestFaceCollider.gameObject.name);
                canDetectFace = false; 
                Finishedrolling = true;
                GH.Addscore(int.Parse(closestFaceCollider.gameObject.name));
                Destroy(gameObject, 3f);
            }
        }
    }
}
