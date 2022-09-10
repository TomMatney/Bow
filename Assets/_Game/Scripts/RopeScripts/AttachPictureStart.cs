using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPictureStart : MonoBehaviour
{
    [SerializeField] RopeBridge ropeBridge;
    [SerializeField] AttachPicture attachPicture;
    [SerializeField] ClickPhoto clickPhoto;
    [SerializeField] Restocker restock;

    [SerializeField] LineRenderer lineRender;
    [SerializeField] int waitAFew = 5;


    public int lineIndex;

    public GameObject CanvasMove;



    // Start is called before the first frame update
    void Start()
    {

        StartWaitAFew();

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MovePictureToFront()
    {
        float speed = .5f;
        Vector3 targetPos = Camera.main.transform.position + Camera.main.transform.forward * .22f + Camera.main.transform.up * .04f; //foward controls how far it its up controls up or down
        Vector3 currentPos = CanvasMove.transform.position; //value to current postion
        
        for(float t  = 0; t < 1; t += Time.deltaTime / speed)
        {
            CanvasMove.transform.position = Vector3.Lerp(currentPos, targetPos, t);
            yield return null;
        }
      
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (restock.inOut)
        {
            ropeBridge.photoPullDown();
            attachPicture.lineIndexNull();
            clickPhoto.TaskOnClick();
        }

        Debug.Log("It went out of trigger");
        StartCoroutine(MovePictureToFront());
       

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
