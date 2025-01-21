using System;
using Common.AssetsSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UIService : MonoBehaviour
{
    private IAssetProvider _assetProvider;
    private IAssetUnloader _loadingScreenUnloader;
    
    public void Init()
    {
        _assetProvider = new AssetProvider();
        _loadingScreenUnloader = new AssetUnloader();
    }

    public async UniTask ShowLoadingScreen()
    {
        var loadingWindow = await _assetProvider.GetAssetAsync<GameObject>("LoadingScreen");
        var loadingWindowPrefab = Instantiate(loadingWindow);
        _loadingScreenUnloader.AddResource(loadingWindow);
        _loadingScreenUnloader.AttachInstance(loadingWindowPrefab);
    }

    public void HideMainMenu()
    {
        _loadingScreenUnloader.Dispose();
    }
}
