using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;
public class DemoManager : MonoBehaviour
{

    public AssetReference localNo;
    private List<IResourceLocation> remoteNos;
    public AssetLabelReference number;
    // Start is called before the first frame update
    
        
    void Start()
    {
       
    }

    public void LoadAssetServer(){

        DisplayNos();
        Addressables.LoadResourceLocationsAsync(number.labelString).Completed += LocationLoaded;
    }

    private void DisplayNos()
    {
     //localNo.InstantiateAsync(Vector3.zero,Quaternion.identity);
       var asyncLoad = UnityEngine.AddressableAssets.Addressables.LoadScene(localNo, LoadSceneMode.Additive);

     //   Addressables.LoadResourceLocationsAsync(number.labelString).Completed +=LocationLoaded;
        Debug.Log(number.labelString);


    }

    private void LocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
    {
        remoteNos = new List<IResourceLocation>(obj.Result);
        StartCoroutine(SpawnRemote());
    }

    IEnumerator SpawnRemote()
    {
        yield return new WaitForSeconds(1f);
        float xoff = -4.0f;
        for(int i = 0; i < remoteNos.Count; i++)
        {
            Vector3 spawnPos = new Vector3(xoff,3,0);
            Addressables.InstantiateAsync(remoteNos[i],spawnPos,Quaternion.identity);
            xoff = xoff + 2.5f;
            yield return new WaitForSeconds(1f);    
        }
    }

  

}
