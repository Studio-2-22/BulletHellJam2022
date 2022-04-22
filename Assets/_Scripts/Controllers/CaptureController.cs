using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
    public static CaptureController instance;
    public GameObject linePrefab;
    public GameObject lineStartPrefab;
    public GameObject lineHeadPrefab;
    public GameObject currentLine;
    private GameObject currentLineStart;
    private GameObject currentLineHead;


    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private PolygonCollider2D polygonCollider;

    private List<Vector2> points;

    public int loopCounter = 0;

    public bool isDrawing;
    public bool hasLeftStart;

    public bool isResetting;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            isDrawing = true;
            CreateLine();     
        }
        if(isDrawing){
            if(Input.GetKey(KeyCode.Space))
            {
                //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 playerPos = transform.position - -transform.up ;
                if(Vector2.Distance(playerPos, points[points.Count - 1]) > 0.3f)
                {
                    UpdateLine(playerPos);
                }
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                
                Debug.Log("Let go"); 
                CancelLine();
               
                
            }
            return;
        }
        if(currentLine != null)
        {
           
            CancelLine();
            
        }
       
    }

    private void CreateLine()
    {
        Vector2 startPos =  transform.position - -transform.up ;
        
        currentLineStart = Instantiate(lineStartPrefab, startPos, Quaternion.identity);
        currentLineHead = Instantiate(lineHeadPrefab, startPos, Quaternion.identity);
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.GetComponent<LineController>().lineStart = currentLineStart;
        currentLine.GetComponent<LineController>().lineHead = currentLineHead;
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        polygonCollider = currentLine.GetComponent<PolygonCollider2D>();
        points.Clear();
        points.Add(startPos);
        points.Add(startPos);
        lineRenderer.SetPosition(0, points[0]);
        lineRenderer.SetPosition(1, points[1]);
        edgeCollider.points = points.ToArray();
        hasLeftStart = false;
        AudioManager.instance.PlayeEffect(5);
    }

    private void UpdateLine(Vector2 newPoint) {
        if(!hasLeftStart)
        {
            if(Vector2.Distance(newPoint, currentLineStart.transform.position) > 2f)
            {
                hasLeftStart = true;
            }
        }
        currentLineHead.transform.position = newPoint;
        points.Add(newPoint);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPoint);
        edgeCollider.points = points.GetRange(0, points.Count-2).ToArray();
    }

    public void ResetLine() {
        isResetting = true;
        AudioManager.instance.PlayeEffect(4); // plays the launch sound because there is not better sound
        loopCounter++;
        Debug.Log("loopCounter: " + loopCounter);
        currentLine.GetComponent<LineController>().loopCompleted = true;
        polygonCollider.points = points.ToArray();
        DestroyLine();
        CreateLine();
        isResetting = false;
    }
    public void DestroyLine() {

        GameObject lineToDestroy = currentLine;
        GameObject startToDestroy = currentLineStart;
        GameObject headToDestroy = currentLineHead;
        StartCoroutine(DestroyLineCo(lineToDestroy, startToDestroy, headToDestroy));
    }

    public IEnumerator DestroyLineCo(GameObject lineObject, GameObject startObject, GameObject headObject) {
        yield return new WaitForSeconds(0.1f);
        Destroy(lineObject);
        Destroy(startObject);
        Destroy(headObject);
    }

    public void CancelLine() {
        isDrawing = false;
        edgeCollider.enabled = false;
        loopCounter = 0;

        //check if first point of line and last point of line are within a distance of 0.1f
        DestroyLine();
    }    
}
