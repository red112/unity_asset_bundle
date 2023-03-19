using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadAssetBundles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myasset"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        var cube = myLoadedAssetBundle.LoadAsset<GameObject>("Cube");
        cube.transform.position = new Vector3(3,0,0);
        Instantiate(cube);

        var sphere = myLoadedAssetBundle.LoadAsset<GameObject>("Sphere");
        sphere.transform.position = new Vector3(0,0,0);
        Instantiate(sphere);

        var capsule = myLoadedAssetBundle.LoadAsset<GameObject>("capsule");
        capsule.transform.position = new Vector3(-3,0,0);
        Instantiate(capsule);

        myLoadedAssetBundle.Unload(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
