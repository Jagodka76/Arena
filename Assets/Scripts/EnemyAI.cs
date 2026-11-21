using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private GameObject me;

    public float SpeedEnemy;
    void Start()
    {
        me = gameObject;
        player = StatsMenager.Instance.gameObject;
        SpeedEnemy = player.transform.GetComponent<PlayerControl>().SpeedPlayer - 0.5f;
    }

    void Update()
    {
        float xx = player.transform.position.x - me.transform.position.x;
        float yy = player.transform.position.y - me.transform.position.y;
        float disss = 0f;

        if(xx < disss)
        {
            xx = -1;
        }
        else if(xx > disss)
        {
            xx = 1;
        }
        else
        {
            xx = 0;
        }

        if (yy < disss)
        {
            yy = -1;
        }
        else if (yy > disss)
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
