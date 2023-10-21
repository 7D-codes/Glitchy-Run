using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    EntityBase entityBase;
    Animator _anim;

    public enum State
    {
        Idle,
        Walking,
        Scared,
        Attacking,
        Dead
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        entityBase = GetComponent<EntityBase>();
        currentState = State.Idle;
    }

    private void Update()
    {
        _anim.SetBool("idle", false);
        _anim.SetBool("walking", false);
        _anim.SetBool("running", false);
        _anim.SetBool("attacking", false);
        _anim.SetBool("dead", false);

        switch (currentState)
        {
            case State.Idle:
                _anim.SetBool("idle", true);
                break;
            case State.Walking:
                _anim.SetBool("walking", true);
                break;
            case State.Scared:
                _anim.SetBool("running", true);
                break;
            case State.Attacking:
                _anim.SetBool("attacking", true);
                break;
            case State.Dead:
                _anim.SetBool("dead", true);
                break;
        }
    }


    public void ChangeState(State newState)
    {
        currentState = newState;
    }
}