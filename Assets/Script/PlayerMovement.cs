using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("���ʳ]�w")]
    public float moveSpeed;

    [Header("����j�w")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("�򥻳]�w")]
    public Transform PlayerCamera;   // ��v��

    private float horizontalInput;   // ���k��V���䪺�ƭ�(-1 <= X <= +1)
    private float verticalInput;     // �W�U��V���䪺�ƭ�(-1 <= Y <= +1)

    private Vector3 moveDirection;   // ���ʤ�V

    private Rigidbody rbFirstPerson; // �Ĥ@�H�٪���(���n��)������(�Ū�)

    private void Start()
    {
        rbFirstPerson = GetComponent<Rigidbody>();
        rbFirstPerson.freezeRotation = true;         // ��w�Ĥ@�H�٪���������A�������n��]���I�쪫��N����
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()   //����馳�����F��ɶq��o�̭� (���ʳt�׷|���í�w�A���bUpdateí�w)
    {
        MovePlayer(); // �u�n�O���󲾰ʡA��ĳ�A���FixedUpdate()
    }

    // ��k�G���o�ثe���a����V��W�U���k���ƭ�
    private void MyInput()                                 //   �k   ��   �W   �U
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");  //   1   -1    0    0
        verticalInput = Input.GetAxisRaw("Vertical");     //    0    0    1   -1
    }

    private void MovePlayer()
    {
        // �p�Ⲿ�ʤ�V(���N�O�p��X�b�PZ�b��Ӥ�V���O�q)
        moveDirection = PlayerCamera.forward * verticalInput + PlayerCamera.right * horizontalInput;
        // ���ʲĤ@�H�٪���
        rbFirstPerson.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}