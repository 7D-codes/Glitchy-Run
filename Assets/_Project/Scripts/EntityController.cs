using UnityEngine;

public class EntityController : MonoBehaviour
{
    private EntityBase entity; // Reference to the EntityBase script
    private StateMachine stateMachine; // Reference to the StateMachine script
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        entity = GetComponent<EntityBase>();
        stateMachine = GetComponent<StateMachine>();

        stateMachine.ChangeState(StateMachine.State.Idle);
    }

    private void Update()
    {
        switch (stateMachine.currentState)
        {
            case StateMachine.State.Idle:
                Idle();
                break;

            case StateMachine.State.Walking:
                Walking();
                break;

            case StateMachine.State.Scared:
                Running();
                break;

            case StateMachine.State.Attacking:
                Attacking();
                break;

            case StateMachine.State.Dead:
                entity.Die();
                break;
        }
    }

    private void Idle()
    {
        _anim.SetBool("idle", true);
    }

    private void Walking()
    {
        _anim.SetBool("walking", true);
        transform.Translate(Vector3.forward * Time.deltaTime * entity.data.moveSpeed);
    }

    private void Running()
    {
        _anim.SetBool("running", true);
        transform.Translate(Vector3.forward * Time.deltaTime * entity.data.runSpeed);
    }

    private void Attacking()
    {
        _anim.SetBool("attacking", true);
    }

}
