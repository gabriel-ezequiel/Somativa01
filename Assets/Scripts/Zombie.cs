using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    public float speed = 5f;
    public float gravity = 50f;
    public float rotSpeed = 50f;
    private float rot;
    private Vector3 moveDirection;
    private Vector3 randomPosition;
    private float time;
    private float timeBetweenRandomPositions = 15f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move(){
        time -= Time.deltaTime;
        if(time <= 0){
            randomPosition = RandomPosition();
            time = timeBetweenRandomPositions;
        }
        // posicao do zumbie sem o eixo y
        Vector3 positionWithoutY = transform.position;
        positionWithoutY.y = 0;

        bool positionBeteenRandomPosition = Vector3.Distance(positionWithoutY, randomPosition) <= 0.05f;

        if(!positionBeteenRandomPosition){
            anim.SetBool("isWalk", true);

            moveDirection = Vector3.forward;
            moveDirection *= speed;

            // rotacao do zumbie
            Quaternion newRotation = Quaternion.LookRotation(randomPosition - positionWithoutY);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);

            moveDirection.y -= gravity;
            moveDirection = transform.TransformDirection(moveDirection);

            controller.Move(moveDirection * Time.deltaTime);
        }
        else{
            anim.SetBool("isWalk", false);
        }
    }

    public Vector3 RandomPosition(){
        Vector3 position = Random.insideUnitSphere * 10;
        position += transform.position;
        position.y = 0;

        return position;
    }
}
