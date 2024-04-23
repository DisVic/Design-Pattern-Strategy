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

        // ����� ����� ������ ��������� ���������, ��������, ��������������
        behavior = new NPCPatroling(npc,patrolPoints,moveSpeed,patrolDestination);
    }

    private void Update()
    {
        // ��������� ���������� �� ������
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= chaseRadius)
        {
            // ���� ����� ���������� ������, ������������� �� ��������� ����� �� �������
            behavior = chasing;
        }
        else if (distanceToPlayer <= jumpRadius)
        {
            // ���� ����� � ���� ������, ������������� �� ��������� ������
            behavior = reacting;
        }
        else
        {
            // � ��������� ������� ���������� ��������� ��������������
            behavior = patroling;
        }

        // ��������� ��������� ���������
        behavior.Act();
    }

    // ����� ��� ��������� ���� (������)
    public void SetTarget(Transform target)
    {
        player = target;
    }
}
