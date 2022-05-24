using UnityEngine;

/*
RequireComponent of the type LineRenderer
A Line renderer is a line that can be visualized and works from point a to point b.
We can connect this with a raycast start point and end point to visualize the line renderer.
 */
[RequireComponent(typeof(LineRenderer))]
public class RaycasterLaser : MonoBehaviour
{

    //The float determines the lenght of the line
    private float m_DefaultLenght = 5.0f;
    
    //Getting the component of linerenderer and since it is on the same object we can make it private.
    private LineRenderer m_LineRenderer;

    //A void awake does something on the loading operation
    private void Awake() 
    {
        // We say that this variables means get the linerenderer component
        m_LineRenderer = GetComponent<LineRenderer>();
    }
    
    //Void start works on the first frame this is active.
    private void Start() 
    {
        //the linerenderer component is enabled.
        m_LineRenderer.enabled = false;
    }
    
    //Late update is being called at the end of the frame.
    private void LateUpdate()
    {
        //we call in a updateline function.
        UpdateLine();
    }
    
    //a Private function that works as a function
    private void UpdateLine()
    {
        //We create a new variable that is also a float type and 
        float targetLenght = m_DefaultLenght;

        RaycastHit hit = CreateRaycast(targetLenght);

        Vector3 endPosition = transform.position + (transform.forward * targetLenght);

        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);

        if (hit.transform != null)
        {
            m_LineRenderer.enabled = true;
        }else {
            m_LineRenderer.enabled = false;
        }
        
        if (hit.transform != null && hit.transform.gameObject.GetComponent<EnemyController>() != null)
        {
            Destroy(hit.transform.gameObject);
        }
    }

    // Creates the Raycast and ignores layer 15(Dot).
    private RaycastHit CreateRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, hitInfo: out hit, m_DefaultLenght);

        return hit;
    }
}
