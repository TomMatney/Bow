using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPictureStart : MonoBehaviour
{
    [SerializeField] RopeBridge ropeBridge;
    [SerializeField] AttachPicture attachPicture;

    [SerializeField] LineRenderer lineRender;
    [SerializeField] int waitAFew = 5;
    public int lineIndex;

    private void OnTriggerExit(Collider other)
    {
        ropeBridge.photoPullDown();
        attachPicture.lineIndexNull();
        Debug.Log("REEEE");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartWaitAFew();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(waitAFew);
        Vector3 postion = lineRender.GetPosition(lineIndex);
        transform.position = postion;
    }

    void StartWaitAFew()
    {
        StartCoroutine(WaitASec());
    }

}
