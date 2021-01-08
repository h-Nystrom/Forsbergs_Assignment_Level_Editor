using System.Runtime.Serialization;
using LevelEditor;
using UnityEngine;

namespace SaveSystem{
    public class TileTypeSerializationSurrogate : ISerializationSurrogate{
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context){
            var tileType = (TileType) obj;
            info.AddValue("name", tileType.name);
            info.AddValue("material", ColorUtility.ToHtmlStringRGBA(tileType.material.color));
            info.AddValue("x", tileType.position.x);
            info.AddValue("y", tileType.position.y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
            ISurrogateSelector selector){
            var tileType = (TileType) obj;
            tileType.name = (string) info.GetValue("name", typeof(string));

            var x = (float) info.GetValue("x", typeof(float));
            var y = (float) info.GetValue("y", typeof(float));
            tileType.position = new Vector2(x, y);

            var colorString = (string) info.GetValue("material", typeof(string));
            var material = new Material(Shader.Find("Sprites/Default")){
                color = ColorUtility.TryParseHtmlString($"#{colorString}", out var color) ? color : Color.white
            };
            tileType.material = material;

            return tileType;
        }
    }
}