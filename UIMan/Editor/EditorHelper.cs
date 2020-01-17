﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnuGames
{
    public static class EditorHelper
    {
        public static T CreateScriptableObject<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            var path = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(T).ToString() + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }

        public static T GetOrCreateScriptableObject<T>() where T : ScriptableObject
        {
            var typeName = typeof(T).Name;
            var guids = AssetDatabase.FindAssets($"t:{typeName}");

            if (guids == null || guids.Length == 0)
            {
                return CreateScriptableObject<T>();
            }

            var file = AssetDatabase.GUIDToAssetPath(guids[0]);
            var asset = AssetDatabase.LoadAssetAtPath<T>(file);
            Selection.activeObject = asset;

            return asset;
        }

        public static T GetPrefab<T>() where T : Object
        {
            var typeName = typeof(T).Name;
            var guids = AssetDatabase.FindAssets($"{typeName} t:{nameof(GameObject)}");

            if (guids == null || guids.Length <= 0)
            {
                UnuLogger.LogError($"Cannot find any prefab of {typeName}.");
                return null;
            }

            var file = AssetDatabase.GUIDToAssetPath(guids[0]);
            var prefab = AssetDatabase.LoadAssetAtPath<T>(file);
            Selection.activeObject = prefab;

            return prefab;
        }
    }
}