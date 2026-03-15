using Unity.AI.Navigation.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   
    private Player _player;    
    public float speed = 5;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    private bool _isWalking;
    
    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (_player.isAppleCollected)
        {
            navMeshAgent.destination = _player.transform.position;
            if (!_isWalking) 
            {
                _animator.SetTrigger("Walk");
                _isWalking = true;
            }
        }
    }
    public void Stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Idle");
    }
}
