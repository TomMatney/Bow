using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPicture : MonoBehaviour
{
    [SerializeField] LineRenderer lineRender;
    public int lineIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 postion = lineRender.GetPosition(lineIndex);
        transform.position = postion;
    }
}
