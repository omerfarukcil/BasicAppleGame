using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public float speed;
    private Rigidbody _rb;
    public bool isAppleCollected;
    private Animator _animator;
    private bool _isCharacterWalking;
   
    void Start()
    {
       _rb=GetComponent<Rigidbody>();
        _animator=GetComponentInChildren<Animator>();
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.showDoor();
            isAppleCollected = true;
            
        }
        if (other.CompareTag("Door")&& isAppleCollected)
        { 
            gameDirector.LevelCompleted();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        playerWalk();
    }

    private void playerWalk()
    {
        var direction = Vector3.zero;
       
        if (direction != Vector3.zero)
        {
            _animator.SetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
            triggerWalkAnimation();
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            triggerWalkAnimation();
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            triggerWalkAnimation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            triggerWalkAnimation();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
            shiftWalkAnimation(1.4f);
        }
        else
        {
            speed = 7;
            shiftWalkAnimation(1f);
        }
        if (direction.magnitude < .5f) 
        { 
            triggerIdleAnimation();
        }
        else
        {
            triggerWalkAnimation();
        }

        transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;
    }

    void triggerWalkAnimation()
    {
        if (!_isCharacterWalking)
        {
            _animator.SetTrigger("Walk");
            _isCharacterWalking = true;
        }
    }
    void triggerIdleAnimation()
    {
        if (_isCharacterWalking)
        {
            _animator.SetTrigger("Idle");
            _isCharacterWalking = false;
        }
    }
    void shiftWalkAnimation(float s)
    {
        _animator.SetFloat("SpeedMultiplier",s);
    }
}
