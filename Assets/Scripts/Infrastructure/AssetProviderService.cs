using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetProviderService
{
    public async Task<GameObject> LoadPrefabAsync(string prefabKey)
    {
        try
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(prefabKey);
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result;
            }
            else
            {
                Debug.LogError($"Failed to load prefab with key: {prefabKey}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while loading prefab with key: {prefabKey}. Error: {ex.Message}");
            return null;
        }
    }
}
