// using UnityEngine;

// public class EnemyBehaviourFunctions : MonoBehaviour

// {


//     // Idle State Behaviours
//     public float playerDetectionAngle = 120f;
//     public int alertRadius = 18f;

//     public bool LineOfSight(Vector3 start, Vector3 end)
//     {
//         RaycastHit hit;
//         if (Physics.Linecast(start, end, out hit, ObstacleMask))
//         {
//             return false;
//         }
//         return true;
//     }

//     private bool IsPlayerInSight(Enemy enemy)
//     {
//         Vector3 directionToPlayer = (player.transform.position - enemy.transform.position).normalized;
//         float angleBetween = Vector3.Angle(enemy.transform.forward, directionToPlayer);

//         if (angleBetween < playerDetectionAngle / 2 && Vector3.Distance(enemy.transform.position, player.transform.position) <= enemy.Stats.Radius)
//         {
//             // Check if the player is within the line of sight
//             if (LineOfSight(enemy.transform.position, player.transform.position))
//             {
//                 return true;
//             }
//         }
//         return false;
//     }

//     private void AlertNearbyEnemies(Enemy enemy)
//     {
//         Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, alertRadius);

//         foreach (Collider collider in nearbyEnemies)
//         {
//             Enemy otherEnemy = collider.GetComponent<Enemy>();
//             if (otherEnemy != null && otherEnemy.currentState == Enemy.EnemyIdleState)
//             {
//                 otherEnemy.currentState = Enemy.EnemyRunState;
//                 // Implement the Running state here for the nearby enemies
//             }
//         }
//     }




// }