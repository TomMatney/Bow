using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBridge : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;


    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    public float ropeSegLen = 0.25f;
    public int segmentLength = 35;
    public float lineWidth = 0.1f;

    private bool moveToMouse;
    private Vector3 mousePostitionWorld;
    private int indexMousePos;

    public AttachPicture selectedPicture;

    // Use this for initialization
    void Start()
    {
        moveToMouse = false;

        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = StartPoint.position;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(StartPoint.position ,EndPoint.position);
    }
    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
        if (Input.GetMouseButtonDown(1))
        {
            this.moveToMouse = true;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<AttachPicture>() != null)
                {
                    var pictureHit = hit.collider.gameObject.GetComponent<AttachPicture>();
                    indexMousePos = pictureHit.lineIndex;
                    selectedPicture = pictureHit;
                }
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            this.moveToMouse = false;
            selectedPicture = null;
        }

      
        if (selectedPicture != null)
        {
            Vector3 screenMousePos = Input.mousePosition;

            this.mousePostitionWorld = Camera.main.ScreenToWorldPoint(new Vector3(screenMousePos.x, screenMousePos.y, 1));
            mousePostitionWorld.x = transform.position.x;
            //print(mousePostitionWorld);
            //print(selectedPicture.transform.position + "teehee");

           
            //for (var i = 0; i < segmentLength; i++)
            //{
            //    Debug.Log($"{mousePostitionWorld} --- {ropeSegments[i].posNow}");
            //    if (Vector3.Distance(mousePostitionWorld, ropeSegments[i].posNow) < .1f)
            //    {
            //        indexMousePos = i;
            //        break;
            //    }
            //}
        }
       
    }

    public void photoPullDown()
    { 
            this.moveToMouse = false;
            selectedPicture = null;
        
    }
    private void FixedUpdate()
    {
        this.Simulate();
    }

    private void Simulate()
    {
        // SIMULATION
        Vector3 forceGravity = new Vector3(0f, -1f, 0f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        //Constrant to First Point 
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.StartPoint.position;
        this.ropeSegments[0] = firstSegment;


        //Constrant to Second Point 
        RopeSegment endSegment = this.ropeSegments[this.ropeSegments.Count - 1];
        endSegment.posNow = this.EndPoint.position;
        this.ropeSegments[this.ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector3 changeDir = Vector3.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector3 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }

            if (selectedPicture !=null && indexMousePos > 0 && indexMousePos < this.segmentLength - 1 && i == indexMousePos )
            {
                RopeSegment segment = this.ropeSegments[i];
                //RopeSegment segment2 = this.ropeSegments[i + 1];
                segment.posNow = new Vector3(this.mousePostitionWorld.x, this.mousePostitionWorld.y, this.mousePostitionWorld.z);
                //segment2.posNow = new Vector3(this.mousePostitionWorld.x, this.mousePostitionWorld.y, this.mousePostitionWorld.z);
                //this.ropeSegments[i + 1] = segment2;
                ropeSegments[i] = segment;

            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}
