using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private GameObject me;

    private float SpeedEnemy;
    void Start()
    {
        me = gameObject;
        player = StatsMenager.Instance.gameObject;
        SpeedEnemy = player.transform.GetComponent<PlayerControl>().Speed + 0.1f;
    }

    void Update()
    {
        float xx = player.transform.position.x - me.transform.position.x;
        float yy = player.transform.position.y - me.transform.position.y;

        if(xx < 0)
        {
            xx = -1;
        }
        else if(xx > 0)
        {
            xx = 1;
        }
        else
        {
            xx = 0;
        }

        if (yy < 0)
        {
            yy = -1;
        }
        else if (yy > 0)
        {
            yy = 1;
        }
        else
        {
            yy = 0;
        }

        if(xx != 0 || yy != 0)
        {
            Vector3 move = new Vector3(xx, yy, 0);
            me.transform.position += move * SpeedEnemy * Time.deltaTime;
        }

        float Dis = Vector3.Distance(player.transform.position, me.transform.position);
        if(Dis <= 0.5)
        {
            StatsMenager.Instance.HPHP -= 5;
            StatsMenager.Instance.UpdateHP();
            Destroy(gameObject);
        }
    }
}
