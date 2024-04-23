using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float playerDetectionRadius = 10f;
    public float chaseRadius = 2f;
    public float jumpRadius = 5f;

    public GameObject npc;
    public Transform player;
    private NPCStrategy behavior;

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private NPCPatroling patroling;
    private NPCReacting reacting;
    private NPCChasing chasing;

    private void Start()
    {
        patroling = new NPCPatroling(npc, patrolPoints, moveSpeed, patrolDestination);
        reacting = new NPCReacting(npc);
        chasing = new NPCChasing(npc, player);

        // Здесь можно задать начальное поведение, например, патрулирование
        behavior = new NPCPatroling(npc,patrolPoints,moveSpeed,patrolDestination);
    }

    private void Update()
    {
        // Проверяем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= chaseRadius)
        {
            // Если игрок достаточно близко, переключаемся на стратегию гонки за игроком
            behavior = chasing;
        }
        else if (distanceToPlayer <= jumpRadius)
        {
            // Если игрок в зоне прыжка, переключаемся на стратегию прыжка
            behavior = reacting;
        }
        else
        {
            // В остальных случаях используем стратегию патрулирования
            behavior = patroling;
        }

        // Выполняем выбранное поведение
        behavior.Act();
    }

    // Метод для установки цели (игрока)
    public void SetTarget(Transform target)
    {
        player = target;
    }
}
