using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;     //�÷��̾��� ��ġ
    Vector3 start_offset; //ī�޶�� �÷��̾� ���� �Ÿ�
    Vector3 moveVector;   //ī�޶� �� ������ �̵��� ��ġ

    float transition = 0.0f; //����  ��
    public static float camera_animate_duration = 3.0f; //ī�޶� �ִϸ��̼� ���� �ð�
    Vector3 animate_offset = new Vector3(0, 5, 5); //���� , �ڷ� 5��ŭ(�ִϸ��̼� ���� ������)

   
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; //�÷��̾� ��ġ ������ �˻�
        start_offset = transform.position - target.position;           //���� �� ����(ī�޶� ��ġ - Ÿ�� ��ġ)
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = target.position + start_offset;
        moveVector.x = 0;                               //ī�޶� x�� ����
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); //y�� ���� 3,5 ���̷� ���� 
                                                        //Mathf.Clamp(��, �ּ�, �ִ�) : �ش� ���� �ּ�, �ִ� ������ �����ϴ� �ڵ�

        if(transition > 1.0f)                           //���� ��(��ȯ ��)�� 1���� ũ�ٸ� moveVector ��ġ�� �̵��մϴ�.
        {
            transform.position = moveVector;
        }
        else
        {
            //��ȯ ���� ���̶��
            transform.position = Vector3.Lerp(moveVector + animate_offset, moveVector, transition); //������ ���� ��ġ���� �÷��̾� ������� ���� �̵�
                                                                                                    //Vector3.Lerp(a,b,t) : a���� b���� t �������� �ε巴�� �̵�(���� ����)
            transition += Time.deltaTime / camera_animate_duration;                                 //��ȯ ���� ������ ������.(������ �ð� / ī�޶� �ִϸ��̼� ���� �ð�)
            transform.LookAt(target.position + Vector3.up);                                         //ī�޶� ���� �̵�(����)
        }
        
    }
}
