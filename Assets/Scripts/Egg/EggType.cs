using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggType : MonoBehaviour
{
    public enum Type
    {
        Normal = 0,
        Rare = 1,
        Legendary = 2,
        Mythical = 3,
        Mystical = 4
    }

   // private static Dictionary<Type, Sprite> _typeToSprite;

    //private void Awake()
    //{
    //    // Инициализируем словарь _typeToSprite
    //    _typeToSprite = new Dictionary<Type, Sprite>();

    //    // Заполняем словарь парами "тип яйца - спрайт"
    //    _typeToSprite[Type.Normal] = Resources.Load<Sprite>("Sprites/Egg_normal");
    //    _typeToSprite[Type.Rare] = Resources.Load<Sprite>("Sprites/Egg_rare");
    //    _typeToSprite[Type.Legendary] = Resources.Load<Sprite>("Sprites/Egg_legendary");
    //    _typeToSprite[Type.Mythical] = Resources.Load<Sprite>("Sprites/Egg_mythical");
    //    _typeToSprite[Type.Mystical] = Resources.Load<Sprite>("Sprites/Egg_mystical");
    //}

    public static string GetName(Type type)
    {
        switch (type)
        {
            case Type.Normal:
                return "Normal";
            case Type.Rare:
                return "Rare";
            case Type.Legendary:
                return "Legendary";
            case Type.Mythical:
                return "Mythical";
            case Type.Mystical:
                return "Mystical";
            default:
                return "";
        }
    }

    //public static Sprite GetSprite(Type type)
    //{
    //    if (_typeToSprite.ContainsKey(type))
    //    {
    //        return _typeToSprite[type];
    //    }
    //    else
    //    {
    //        Debug.LogError("Unknown egg type: " + type);
    //        return null;
    //    }
    //}
}
