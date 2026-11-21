using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerControl : MonoBehaviour
{
    public float SpeedPlayer = 5;
    private float verticalMove;
    private float horizontalMove;

    public GameObject Bullet;
    private GameObject PlayerObject;

    private float arenaSize;
    private float TimeDead;
    private float TiemToShot;

    private Camera Cam;

    private bool outSideArena;
    private void Awake()
    {
        PlayerObject = this.gameObject;
        arenaSize = 12f;
        Cam = Camera.main;
    }

    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical");
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if(PlayerObject != null)
        {
            if(horizontalMove != 0f || verticalMove != 0f)
            {

                float distance = Vector3.Distance(new Vector3(0,0,0), PlayerObject.transform.position);
                if(distance <= arenaSize)
                {
                    Vector3 move = new Vector3(horizontalMove, verticalMove, 0);
                    PlayerObject.transform.position += move * SpeedPlayer * Time.deltaTime;
                    outSideArena = false;
                }
                else
                {
                    Vector3 move = new Vector3(horizontalMove, verticalMove, 0);
                    PlayerObject.transform.position += move * SpeedPlayer * Time.deltaTime;
                    outSideArena = true;
                }
            }

            if(Bullet != null && Input.GetMouseButtonDown(0) && TiemToShot < Time.time)
            {
                GameObject Bul = Instantiate(Bullet, transform.position, transform.rotation);
                Rigidbody2D BulRb = Bul.transform.GetComponent<Rigidbody2D>();

                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 - Cam.transform.position.z);
                Vector3 mouseWorld = Cam.ScreenToWorldPoint(mousePos);

                Vector3 direction = (mouseWorld - PlayerObject.transform.position).normalized;

                BulRb.linearVelocity = direction * 3 * SpeedPlayer;

                TiemToShot = Time.time + 0.25f;
            }
        }

        if (outSideArena)
        {
            if (TimeDead < Time.time)
            {
                TimeDead = Time.time + 1;
                StatsMenager.Instance.HPHP -= 1;
                StatsMenager.Instance.UpdateHP();
            }
        }
    }
}
