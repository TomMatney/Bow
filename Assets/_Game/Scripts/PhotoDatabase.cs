using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoDatabase : MonoBehaviour
{
    public System.Action OnDatabaseChanged;
    public List<PhotoData> photos = new List<PhotoData>();

    public void AddPhoto(PhotoData photoData)//parameter what it can take in
    {
        photos.Add(photoData); //this is getting the info out
        OnDatabaseChanged.Invoke();
    }

    public PhotoData GetLastPhoto()
    {
        if(photos.Count == 0)
        {
            return null;
        }
        return photos[photos.Count - 1];
        
    }
    public List<PhotoData> GetAllPhotos()
    {
        return photos;
    }
    public PhotoData GetFirstPhoto()
    {
        return photos[0];
    }
    public PhotoData GetPhotoAtIndex(int index)
    {
        if (photos.Count <= index)
        {
            return null;
        }
        return photos[index];
    }
    //GetPhotoAtIndex(2);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
