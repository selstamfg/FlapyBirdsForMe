using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float incubationTime = 10f; // врем€ инкубации
    private bool isHatched = false; // флаг, показывающий, вылупилось ли €йцо
    private bool isBeingDragged = false; // флаг, показывающий, перетаскиваетс€ ли €йцо в данный момент
    private Vector2 startPosition; // начальна€ позици€ €йца
    private float timeLeft; // оставшеес€ врем€ инкубации
    private Collider2D eggCollider; // коллайдер €йца
    private Nest currentNest; // текущее гнездо

    void Start()
    {
        startPosition = transform.position;
        eggCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isHatched)
        {
            // если €йцо вылупилось, удал€ем его из €чейки на сцене и освобождаем еЄ
            currentNest.RemoveEgg();
            Destroy(gameObject);
        }
        else if (timeLeft > 0)
        {
            // если €йцо еще не вылупилось и осталось врем€ инкубации,
            // уменьшаем оставшеес€ врем€ на каждом кадре
            timeLeft -= Time.deltaTime;
        }
        else
        {
            // иначе €йцо вылупилось
            isHatched = true;
            eggCollider.enabled = false; // отключаем коллайдер, чтобы €йцо больше не могло сталкиватьс€ с другими объектами
            transform.GetChild(0).gameObject.SetActive(true); // включаем модель вылупившегос€ птенца
        }
    }

    void OnMouseDown()
    {
        if (!isHatched)
        {
            // запоминаем текущее гнездо
            currentNest = transform.parent.GetComponent<Nest>();
            // запоминаем начальную позицию €йца и выставл€ем флаг перетаскивани€
            startPosition = transform.position;
            isBeingDragged = true;
            // удал€ем €йцо из гнезда
            currentNest.RemoveEgg();
        }
    }

    void OnMouseUp()
    {
        if (!isHatched && isBeingDragged)
        {
            // выставл€ем флаг перетаскивани€ в false
            isBeingDragged = false;
            // ищем ближайшее гнездо
            GameObject[] nests = GameObject.FindGameObjectsWithTag("Nest");
            Nest nearestNest = null;
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject nest in nests)
            {
                Nest nestScript = nest.GetComponent<Nest>();
                float distance = Vector2.Distance(transform.position, nest.transform.position);
                if (distance < nearestDistance && nestScript.HasSpace())
                {
                    nearestNest = nestScript;
                    nearestDistance = distance;
                }
            }
            if (nearestNest != null)
            {
                // если нашли ближайшее гнездо, перемещаем €йцо в него
                transform.position = nearestNest.GetFreeCellPosition();
                // помещаем €йцо в гнездо и выставл€ем текущее гнездо в null
                nearestNest.PlaceEgg(this);
                currentNest = null;
            }
            else
            {
                // если ближайшего гнезда не нашли, возвращаем €йцо на начальную позицию
                transform.position = startPosition;
                // возвращаем €йцо в гнездо, откуда оно было вз€то
                currentNest.PlaceEgg(this);
                currentNest = null;
            }
        }
    }
}

