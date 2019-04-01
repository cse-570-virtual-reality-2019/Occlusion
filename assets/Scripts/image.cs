using UnityEngine;
using UnityEngine.UI;

public class image : MonoBehaviour
{
    public RawImage mRawImage;
    public MultiSourceManager mMultiSCource;
    // Update is called once per frame
    void Update()
    {
        mRawImage.texture = mMultiSCource.GetColorTexture();
        
    }
}
