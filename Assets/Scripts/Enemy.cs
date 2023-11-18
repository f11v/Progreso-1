using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float chaseDistance = 200.0f;
    public float moveSpeed = 5.0f;
    public float idleTime = 4.0f; 
    public Animator ani;
    public Transform myPlayer;
    public Quaternion targetRotation;
    public float degree;

    private float idleTimer;

    void Start()
    {
        ani = GetComponent<Animator>();
        GameObject playerObject = GameObject.Find("MyPlayer");

        if (playerObject != null)
        {
            myPlayer = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el nombre 'MyPlayer'.");
        }
    }

    public void Comportamiento_Enemigo()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, myPlayer.position);

        if (distanceToPlayer > chaseDistance)
        {
            
            ani.SetBool("run", false);

            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                
                targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                idleTimer = 0;
            }

            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 0.5f);
        }
        else
        {
            
            ani.SetBool("run", true);

            var lookPos = myPlayer.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}







