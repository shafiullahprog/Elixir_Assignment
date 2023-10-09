using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] Transform target_Player;
    [SerializeField] GameObject projectTile;
    [SerializeField] float bulletSpeed, isInRange;
    bool isAttackAlready;
    float attackRange, attackTime = 3f;
    // Update is called once per frame
    void Update()
    {
        target_Player = GameObject.Find("Player").transform;
        attackRange = Vector3.Distance(transform.position, target_Player.position);

        if(attackRange <= isInRange)
            AttackFromConstantPlace();
    }

    public void AttackFromConstantPlace()
    {
        transform.LookAt(target_Player);
        if (!isAttackAlready)
        {
            Rigidbody rb = Instantiate(projectTile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletSpeed);
            isAttackAlready = true;
            Invoke(nameof(ResetAttack), attackTime);
        }
    }

    void ResetAttack()
    {
        isAttackAlready = false;
    }
}
