using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class measureDepth : MonoBehaviour
{
    private ushort[] mDepthData=null;
    public MultiSourceManager mMultiSource;
    public Material m1, m2;
    public GameObject sphere;

    private int arraySize;
    private KinectSensor mSensor = null;
    private void Awake()
    {
        mSensor = KinectSensor.GetDefault();
    }
    private void Update()
    {
        mDepthData = mMultiSource.GetDepthData();
        if (check())
        {
           //Debug.Log(mDepthData[81795]);
            sphere.GetComponent<Renderer>().material = m2;
            //Debug.Log("Enter");
        }
        else
        {
            sphere.GetComponent<Renderer>().material = m1;
            //Debug.Log(mDepthData[81795]);
            //Debug.Log(mDepthData[arraySize / 2]);
            //Debug.Log("Exit");
        }
    }
    private bool check()
    {
        for (int i = 82634; i < 111818; i = i + 512)
        {
            for (int j = 0; j < 57; j++)
            {
                if (mDepthData[i + j] > 0 && mDepthData[i + j] < 900)
                {
                    Debug.Log(mDepthData[i + j]);
                    return true;
                }
            }
        }
        //Debug.Log(mDepthData[82634]);
        return false;
    }
}