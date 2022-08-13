using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBaseVeiwer : MonoBehaviour
{
    [SerializeField] PhotoDatabase photoDatabase;
    public Image photoImage0; //alt enter to find fixes
    public Image photoImage1;
    public Image photoImage2;
    public Image photoImage3;
    public Image photoImage4;
    public Image photoImage5;



    public void OnEnable()
    {
        PhotoDatabase.PhotoData photo0 = photoDatabase.GetPhotoAtIndex(0);
        if(photo0 != null)
        {
            photoImage0.sprite = photo0.texture;
        }

        PhotoDatabase.PhotoData photo1 = photoDatabase.GetPhotoAtIndex(1);
        if (photo1 != null)
        {
            photoImage1.sprite = photo1.texture;
        }
        PhotoDatabase.PhotoData photo2 = photoDatabase.GetPhotoAtIndex(2);
        if (photo2 != null)
        {
            photoImage2.sprite = photo2.texture;
        }
        PhotoDatabase.PhotoData photo3 = photoDatabase.GetPhotoAtIndex(3);
        if (photo3 != null)
        {
            photoImage3.sprite = photo3.texture;
        }
        PhotoDatabase.PhotoData photo4 = photoDatabase.GetPhotoAtIndex(4);
        if (photo4 != null)
        {
            photoImage4.sprite = photo4.texture;
        }
        PhotoDatabase.PhotoData photo5 = photoDatabase.GetPhotoAtIndex(5);
        if (photo5 != null)
        {
            photoImage5.sprite = photo5.texture;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
