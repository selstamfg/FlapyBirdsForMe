using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysticEgg : MonoBehaviour
{
    [SerializeField] private EggType.Type[] _possibleEggTypes;
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;

    public Egg2 Open()
    {
        EggType.Type openedType = _possibleEggTypes[Random.Range(0, _possibleEggTypes.Length)];
        string openedName = EggType.GetName(openedType);

        GameObject openedEggObject = Instantiate(_eggPrefab, _gridLayoutGroup.transform);
        Egg2 openedEgg = openedEggObject.GetComponent<Egg2>();
        openedEgg.SetType(openedType);
        return openedEgg;
    }
}
