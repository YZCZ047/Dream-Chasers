using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; // С�ֵ��ƶ��ٶ�
    private float stayTiming;
    public float stayTime;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    //[SerializeField] private LayerMask whatIsGround;

    private Vector2 moveDirection = Vector2.left;
    public bool facRight = false; // ��ʼ�ƶ�����

    void Update()
    {


        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance);

        if (hit.collider != null)
        {
            // �����ײ�����壬������������Ƿ�Ϊ "MoveZone"
            if (hit.collider.name == "MoveZone")
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                stayTiming = stayTime;
            }
            // �����ײ���岻�� "MoveZone" ������ null�����û����ײ���κ����壩
            else
            {
                stayTiming -= Time.deltaTime;
            }
        }
        else
        {
            // ���û����ײ���κ����壬ִ���ⲿ���߼�
            stayTiming -= Time.deltaTime;
        }


        if (stayTiming < 0)
        {
            if (facRight)
            {
                moveDirection = Vector2.left;
                facRight = !facRight;
                FlipDirection();
                return;
            }
            else
            {
                moveDirection = Vector2.right;
                facRight = !facRight;
                FlipDirection();
                return;

            }
        }

    }

    void FlipDirection()
    {
        // ��תС�ֵĳ���
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Debug.Log("Direction flipped!");
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}
