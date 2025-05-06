using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;     //플레이어의 위치
    Vector3 start_offset; //카메라와 플레이어 간의 거리
    Vector3 moveVector;   //카메라가 매 프레임 이동할 위치

    float transition = 0.0f; //보간  값
    public static float camera_animate_duration = 3.0f; //카메라 애니메이션 지속 시간
    Vector3 animate_offset = new Vector3(0, 5, 5); //위로 , 뒤로 5만큼(애니메이션 시작 오프셋)

   
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; //플레이어 위치 씬에서 검색
        start_offset = transform.position - target.position;           //시작 값 설정(카메라 위치 - 타겟 위치)
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = target.position + start_offset;
        moveVector.x = 0;                               //카메라 x축 고정
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); //y축 범위 3,5 사이로 제한 
                                                        //Mathf.Clamp(값, 최소, 최대) : 해당 값을 최소, 최대 범위로 제한하는 코드

        if(transition > 1.0f)                           //보간 값(전환 값)이 1보다 크다면 moveVector 위치로 이동합니다.
        {
            transform.position = moveVector;
        }
        else
        {
            //전환 진행 중이라면
            transform.position = Vector3.Lerp(moveVector + animate_offset, moveVector, transition); //오프셋 적용 위치에서 플레이어 방향까지 보간 이동
                                                                                                    //Vector3.Lerp(a,b,t) : a부터 b까지 t 간격으로 부드럽게 이동(선형 보간)
            transition += Time.deltaTime / camera_animate_duration;                                 //전환 값이 서서히 증가함.(프레임 시간 / 카메라 애니메이션 지속 시간)
            transform.LookAt(target.position + Vector3.up);                                         //카메라 시점 이동(위로)
        }
        
    }
}
