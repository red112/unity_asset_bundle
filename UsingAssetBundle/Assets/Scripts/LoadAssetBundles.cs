using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;


public class LoadAssetBundles : MonoBehaviour
{
    void Start() {
        StartCoroutine(GetAssetBundle());
    }
 
    IEnumerator GetAssetBundle() {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://red112.github.io/unity_asset_bundle/myasset");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            AssetBundle myLoadedAssetBundle = DownloadHandlerAssetBundle.GetContent(www);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield return null;
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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
