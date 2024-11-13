using UnityEngine;
using UnityEngine.AI;

public class RaycastToNavMesh : MonoBehaviour
{
    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public float rayDistance = 100f; // Maximum distance for the raycast

    private LineRenderer lineRenderer; // Reference to the LineRenderer component
    public Color rayColor = Color.red;
    void Start()
    {
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = rayColor;
        lineRenderer.endColor = rayColor;
        lineRenderer.startWidth = 0.05f; // Adjust width of the ray
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2; // Two points for the start and end of the ray
    }
    void Update()
    {
        // Check for mouse button click (you can replace this with your input system)
        if (Input.GetMouseButtonDown(0))
        {
            SetDestination();
        }
    }

    public void SetDestination()
    {
        // Create a ray from this object's position in the forward direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Check if the raycast hit a valid NavMesh area
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(hit.point, out navHit, 1.0f, NavMesh.AllAreas))
            {
                // Set the destination for the NavMeshAgent
                agent.SetDestination(navHit.position);
            }
        }
    }
    void DrawRay()
    {
        // Set the positions for the Line Renderer
        lineRenderer.SetPosition(0, transform.position); // Start point of the ray
        lineRenderer.SetPosition(1, transform.position + transform.forward * rayDistance); // End point of the ray

        // Optionally, disable the Line Renderer if you want it to disappear after a click
        // lineRenderer.enabled = false; // Uncomment to disable after the ray is drawn once
    }
}
