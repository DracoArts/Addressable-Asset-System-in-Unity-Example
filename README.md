
# Welcome to DracoArts

![Logo](https://dracoarts-logo.s3.eu-north-1.amazonaws.com/DracoArts.png)




#  Addressable Asset System in Unity Example
The Addressable Asset System is Unity’s recommended solution for modern asset management, offering a robust, scalable, and efficient way to handle content in games of all sizes. By decoupling asset references from their storage locations, it provides greater flexibility, better performance, and easier maintenance compared to older methods. Whether for small indie projects or large AAA games with dynamic content, Addressables streamline development and improve runtime efficiency.

For developers transitioning from Resources.Load or manual AssetBundles, adopting Addressables can significantly reduce complexity while unlocking powerful new features for content delivery and optimization.

# Core Purpose
The primary goal of the Addressable system is to allow developers to load assets using logical string-based addresses rather than hard references or resource paths. This decouples asset references from their physical storage location, making it easier to manage large projects, support downloadable content (DLC), optimize memory usage, and reduce build times.

# Key Benefits & Features
## 1. Simplified Asset Loading & Management
- Assets are assigned unique addresses (e.g., "Characters/Hero" or "Environments/Forest"), allowing them to be loaded dynamically at runtime without direct scene dependencies.

- Eliminates the need for hard references in scripts, reducing coupling and making prefabs and scenes more modular.

## 2. Efficient Asset Bundling & Delivery
- Automatically packages assets into optimized AssetBundles based on dependency analysis.

- Supports remote hosting, enabling dynamic content updates without requiring full game patches.

- Reduces initial install size by allowing assets to be downloaded on-demand.

## 3. Advanced Memory Management
- Provides fine-grained control over when assets are loaded and unloaded.

- Prevents memory leaks by tracking references and allowing manual or automatic release of unused assets.

 - Supports asynchronous loading to avoid frame hitches and maintain smooth performance.
## 4. Cross-Platform & Variant Support
- Handles platform-specific assets automatically (e.g., different textures for Android vs. iOS).

- Supports asset variants, allowing different versions of an asset (e.g., HD vs. low-res) to be loaded based on runtime conditions.

## 5. Build Flexibility & Content Organization
- Groups assets logically (e.g., "Level1_Assets," "UI_Assets") regardless of their physical storage.

- Enables incremental builds, reducing iteration time during development.

- Generates a content catalog that tracks all addressable assets and their locations (local or remote).
## 6. Asynchronous Loading & Dependency Handling
- All loading operations are non-blocking, preventing frame drops.

- Automatically resolves and loads dependencies (e.g., materials, textures, and prefabs linked to a model).

# Use Cases
- Live Games & DLCs: Update content post-launch without full app updates.

- Open-World Games: Stream assets dynamically as players explore.

- Mobile Optimization: Reduce install size by downloading assets only when needed.

- Multiplatform Projects: Manage different asset versions per platform seamlessly.

# 🛠️ Setting Up Addressables
## Step 1: Install the Addressables System
- Using Unity's Package Manager, install the Addressables package. This adds the necessary tools and systems to your project.

## Step 2: Mark Assets as Addressable
In your project, select any asset (prefab, texture, audio, etc.) and check the “Addressable” box in the Inspector. You’ll assign it a unique name or "address" for loading later.

## Step 3: Organize with Addressable Groups
All addressable assets are automatically added to groups. These groups help you organize content for local or remote loading. You can control how assets are bundled and where they're stored.

## Step 4: Build Content
From the Addressables window, you can build your content. This prepares the addressable assets for use in the final game. Unity creates catalogs and bundles based on your setup.

# 🧳 How to Use Addressables in Practice
- Once you’ve marked assets as addressable and built the groups:

- You load them during gameplay using their address.

- After use, you can unload them to free up memory.

- If you’re using remote hosting, Unity will automatically download the required assets from the server when needed.

- Addressables can be used for scenes, prefabs, textures, audio, and more.
## Usage/Examples
Load Next Scene

    public string NextSceneAddress;

	Button m_NextButton;
	
	// Use this for initialization
	void Start ()
	{
		m_NextButton = GetComponent<Button>();
		m_NextButton.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick()
	{
		Addressables.LoadSceneAsync(NextSceneAddress);
	}

Assets Load From Server

    public AssetReference localNo;
    private List<IResourceLocation> remoteNos;
    public AssetLabelReference number;
    // Start is called before the first frame update

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

## Images

####  Load Next Scene 
    

![](https://github.com/AzharKhemta/Gif-File-images/blob/main/Addressable%20Scene%20Load%20part%201.gif?raw=true)

 #### Assets Load Fromer Server 
 
![](https://github.com/AzharKhemta/Gif-File-images/blob/main/Addressable%20Load%20Assets%20Part%202.gif?raw=true)

## Authors

- [@MirHamzaHasan](https://github.com/MirHamzaHasan)
- [@WebSite](https://mirhamzahasan.com)


## 🔗 Links

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/company/mir-hamza-hasan/posts/?feedView=all/)
## Documentation

[Unity Addressables](https://learn.unity.com/course/get-started-with-addressables)




## Tech Stack
**Client:** Unity,C#

**Plugin:** Unity Addressables



