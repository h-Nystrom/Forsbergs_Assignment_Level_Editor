using System;
using UnityEditor;
using UnityEngine;

namespace LevelEditor{
    //TODO: Make this class a struct and remove mono behaviour and using Unity editor!
    //TODO: make tests for code!
    public class CreateTileType : MonoBehaviour{
        const int MaxTileTypes = 12;
        //TODO: Remove-------->
        const string MaterialAssetPath = "Assets/Materials/TileMaterials";
        const string TileSOAssetPath = "Assets/ScriptableObjects/TileSO";
        [SerializeField] GameObject tilePrefab;
        //TODO: Remove---------
        
        //TODO: Save in json instead of PlayerPrefs!
        public static int Count{
            get => PlayerPrefs.GetInt("TileTypes", 0);
            private set => PlayerPrefs.SetInt("TileTypes", value);
        }
        //TODO: Remove start method!
        void Start(){
            var findAssets = AssetDatabase.FindAssets("t:material", new[] {MaterialAssetPath});
            Count = findAssets.Length;
            NewTileType("Test", tilePrefab,Color.blue);
        }
        //TODO:Save scriptableObject in json file format!
        public static void NewTileType(string name, GameObject tilePrefab, Color color){
            if (Count >= MaxTileTypes){
                print("Max spawns reached!");
                return;
            }
            Count++;
            var tileSo = ScriptableObject.CreateInstance<TileSO>();
            tileSo.NewInstance(CreateMaterial(name,color),tilePrefab,name);
        }
        //TODO: Change to json instead of using unityEditor methods!
        static Material CreateMaterial(string name, Color color){
            var material = new Material(Shader.Find("Sprites/Default"));
            material.color = color;
            AssetDatabase.CreateAsset(material, $"{MaterialAssetPath}/{name}_{Count}.mat");
            return material;
        }
        //TODO: Rework this!
        static void DestroyTileType(Material material){
            AssetDatabase.DeleteAsset($"{MaterialAssetPath}/{material.name}");
        }
    }
}

