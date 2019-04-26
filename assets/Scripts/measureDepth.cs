using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Windows.Kinect;

public class measureDepth : MonoBehaviour
{
    private ushort[] mDepthData=null;
    public MultiSourceManager mMultiSource;
    public Material m1, m2;
    public GameObject sphere;
    private int StartPoint,size;
    public Texture2D mdepthtexture;
    private CoordinateMapper mMapper = null;
    private Texture2D oldt;

    

    public AR depthvalue;

    private int arraySize;
    private KinectSensor mSensor = null;
    private readonly Vector2Int mDepthResolution = new Vector2Int(512, 424);

    private CameraSpacePoint[] cameraSpacePoints = null;
    private ColorSpacePoint[] colorSpacePoints = null;

    private void Awake()
    {
        //StartPoint = 82634;
        //size = 57;

        mSensor = KinectSensor.GetDefault();
        int arraysize = mDepthResolution.x * mDepthResolution.y;
        cameraSpacePoints = new CameraSpacePoint[arraysize];
        colorSpacePoints = new ColorSpacePoint[arraysize];
        mdepthtexture = createtexture1();
    }
    private void Update()
    {
        
        mDepthData = mMultiSource.GetDepthData();
        oldt = mMultiSource.GetColorTexture();
        mdepthtexture = createtexture();
        //Debug.Log(mDepthData[81795]);
        /*if (check())
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
        }*/
    }
    /*private bool check()
    {
        for (int i = StartPoint; i < StartPoint+512*size; i = i + 512)
        {
            for (int j = 0; j < size; j++)
            {
                if (mDepthData[i + j] > 0 && mDepthData[i + j] < 900)
                {
                    //Debug.Log(mDepthData[i + j]);
                    return true;
                }
            }
        }
        
        //Debug.Log(mDepthData[82634]);
        return false;
    }*/
    private Texture2D createtexture()
    {
        Texture2D newTexture = new Texture2D(512, 424, TextureFormat.ARGB32, false);

        newTexture.filterMode = FilterMode.Point;
        //int fg = 0;
        for (int i = 0; i < 512; i++)
        {
            for (int j = 0; j < 424; j++)
            {
                int x = i + (j * 512);
                try
                {
                    if (mDepthData[x] > depthvalue.depth || depthvalue.depth == -1 || mDepthData[x]==0)
                    {

                        newTexture.SetPixel(i, j, Color.clear);
                    }
                    else
                    {
                        newTexture.SetPixel(i, j, oldt.GetPixel((int)(i * 3.75), (int)(j * 2.54)));
                        
                        //oldt.GetPixel((int)(i*3.75),(int)(j*2.54))
                        /*if (fg == 0)
                        {
                            fg = 1;
                            Debug.Log("ooh");
                        }*/
                    }
                }
                catch(Exception e)
                {
                    newTexture.SetPixel(i, j, Color.clear);
                }
            }
        }

        
        newTexture.Apply();
        
        return newTexture;
    }
    private Texture2D createtexture1()
    {
        Texture2D newTexture = new Texture2D(512, 424, TextureFormat.ARGB32, false);
        for (int i = 0; i < 512; i++)
        {
            for (int j = 0; j < 424; j++)
            {
                newTexture.SetPixel(i, j, Color.clear);
            }
        }


        newTexture.Apply();
        return newTexture;
    }
}