using UnityEngine;

public class BulletScri : MonoBehaviour
{
    private Transform EnemBox;

    private float TimeToDie;

    private Vector3 TurningPoint;
    private Camera Cam;

    private int ColNum = 0;

    private void Start()
    {
        TimeToDie = 1.5f + Time.time;
        EnemBox = EnemySpawner.Instance.transform;
        Cam = Camera.main;
    }

    void Update()
    {
        if (Time.time > TimeToDie)
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Cam.transform.position.z);
            TurningPoint = Cam.ScreenToWorldPoint(mousePos);
            
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Cam.transform.position.z);
            Vector3 mouseNow = Cam.ScreenToWorldPoint(mousePos);

            float xx = mouseNow.x - TurningPoint.x;
            float yy = mouseNow.y - TurningPoint.y;

            if (xx < 0)
            {
                xx = -1;
            }
            else if (xx > 0)
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

            Vector3 move = new Vector3(xx, yy, 0);
            this.transform.position += move * 2f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.parent == EnemBox)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        //Jedno odbice bo po dwóch nie am zastoswoania
        if(ColNum == 1)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        ColNum += 1;
    }
}
