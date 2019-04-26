using UnityEngine;
using UnityEngine.UI;

public class image : MonoBehaviour
{
    public RawImage mRawImage;
    public RawImage occluding;
    public MultiSourceManager mMultiSCource;
    public measureDepth mMeasureDepth;
    // Update is called once per frame
    void Update()
    {
        mRawImage.texture = mMultiSCource.GetColorTexture();
        occluding.texture = mMeasureDepth.mdepthtexture;
    }
}
