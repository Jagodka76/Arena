using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;
    private float verticalMove;
    private float horizontalMove;

    private GameObject PlayerObject;

    private float arenaSize;
    private void Awake()
    {
        PlayerObject = this.gameObject;
        arenaSize = 12f;
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
                    PlayerObject.transform.position += move * Speed * Time.deltaTime;
                }
                else
                {
                    Vector3 move = new Vector3(horizontalMove, verticalMove, 0);
                    PlayerObject.transform.position += move * Speed * Time.deltaTime;
                }
            }
        }
    }
}
