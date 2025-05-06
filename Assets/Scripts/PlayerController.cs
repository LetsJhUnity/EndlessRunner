using UnityEditor.Rendering;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController; //������Ʈ

    private Vector3 moveVector;             //���� ����
    private float speed = 5.0f;             // �÷��̾� �ӵ�
    private float vertical_velocity = 0.0f; // ���� �ӵ�(����)
    private float gravity = 12.0f;          // �߷� ��

   
    void Start()
    {
        characterController = GetComponent<CharacterController>(); //ĳ���� ������Ʈ ����
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���� �� ���� �ð� ������ �ڵ����� ������ �̵��ϸ� �÷��̾��� �Է��� �����ϰ� ī�޶� ���� ȿ���� ����մϴ�.
        if (Time.timeSinceLevelLoad < CameraController.camera_animate_duration)
        {
            characterController.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        //�� ������ ���� �̵� ���Ϳ� ���� �ʱ�ȭ
        moveVector = Vector3.zero;


        //���� ������� ��� -0.5�� �����մϴ�.(�ٴڿ� �پ��ֵ���)
        if(characterController.isGrounded)
        {
            vertical_velocity = -0.5f;
        }
        else
        {
            //���߿� ���� ��� �߷� ����ŭ ���� �ӵ��� ����
            vertical_velocity -= gravity * Time.deltaTime;
        }

        //���� ���� ����
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;     
        moveVector.y = vertical_velocity;  
        moveVector.z = speed;

        //������ �̵�
        characterController.Move(moveVector * Time.deltaTime);

    }
}
