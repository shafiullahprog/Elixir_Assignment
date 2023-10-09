using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target_Player;

    private void Start()
    {
        target_Player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        agent.SetDestination(target_Player.position);
    }
}
