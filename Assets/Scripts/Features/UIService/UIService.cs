using System;
using Common.AssetsSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UIService : MonoBehaviour
{
    private IAssetProvider _assetProvider;
    private IAssetUnloader _loadingScreenUnloader;
    private IAssetUnloader _mainScreenUnloader;
    
    public void Init()
    {
        _assetProvider = new AssetProvider();
        _loadingScreenUnloader = new AssetUnloader();
        _mainScreenUnloader = new AssetUnloader();
    }

    public async UniTask<LoadingScreenView> ShowLoadingScreen()
    {
        var loadingWindow = await _assetProvider.GetAssetAsync<GameObject>("LoadingScreen");
        var loadingWindowView = Instantiate(loadingWindow).GetComponent<LoadingScreenView>();
        _loadingScreenUnloader.AddResource(loadingWindow);
        _loadingScreenUnloader.AttachInstance(loadingWindowView.gameObject);
        
        return loadingWindowView;
    }

    public void HideLoadingScreen()
    {
        _loadingScreenUnloader.Dispose();
    }
    
    public async UniTask<MainMenuView> ShowMainScreen()
    {
        var mainScreenWindow = await _assetProvider.GetAssetAsync<GameObject>("MainScreen");
        var mainScreenWindowView = Instantiate(mainScreenWindow).GetComponent<MainMenuView>();
        _mainScreenUnloader.AddResource(mainScreenWindow);
        _mainScreenUnloader.AttachInstance(mainScreenWindowView.gameObject);
        
        return mainScreenWindowView;
    }
}
