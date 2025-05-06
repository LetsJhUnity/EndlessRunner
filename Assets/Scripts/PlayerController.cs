using UnityEditor.Rendering;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController; //컴포넌트

    private Vector3 moveVector;             //방향 벡터
    private float speed = 5.0f;             // 플레이어 속도
    private float vertical_velocity = 0.0f; // 수직 속도(점프)
    private float gravity = 12.0f;          // 중력 값

   
    void Start()
    {
        characterController = GetComponent<CharacterController>(); //캐릭터 컴포넌트 연결
    }

    // Update is called once per frame
    void Update()
    {
        //게임 시작 후 일정 시간 동안은 자동으로 앞으로 이동하며 플레이어의 입력을 무시하고 카메라 연출 효과로 사용합니다.
        if (Time.timeSinceLevelLoad < CameraController.camera_animate_duration)
        {
            characterController.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        //매 프레임 마다 이동 벡터에 대한 초기화
        moveVector = Vector3.zero;


        //땅에 닿아있을 경우 -0.5로 유지합니다.(바닥에 붙어있도록)
        if(characterController.isGrounded)
        {
            vertical_velocity = -0.5f;
        }
        else
        {
            //공중에 있을 경우 중력 값만큼 수직 속도가 감소
            vertical_velocity -= gravity * Time.deltaTime;
        }

        //방향 벡터 설정
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;     
        moveVector.y = vertical_velocity;  
        moveVector.z = speed;

        //방향대로 이동
        characterController.Move(moveVector * Time.deltaTime);

    }
}
