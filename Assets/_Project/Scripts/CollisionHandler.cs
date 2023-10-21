using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    EntityBase entity;
    StateMachine stateMachine;
    
    private void Start()
    {
        entity = GetComponent<EntityBase>();
        stateMachine = GetComponent<StateMachine>();
    }
    public void  OnCollisionEnter(Collision other)
    {
        string parentTag = transform.parent.tag;
        
        if (other.gameObject.CompareTag("Hunter"))
        {
            if (parentTag == "Hunter")
            {
                stateMachine.ChangeState(StateMachine.State.Attacking);
            }
            else if (parentTag == "Prey")
            {
                stateMachine.ChangeState(StateMachine.State.Scared);   
            }
        }
        else if (other.gameObject.CompareTag("Prey"))
        {
            if (parentTag == "Hunter")
            {
                stateMachine.ChangeState(StateMachine.State.Scared);
            }
            else if (parentTag == "Prey")
            {
                stateMachine.ChangeState(StateMachine.State.Attacking);   
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (parentTag == "Hunter")
            {
                stateMachine.ChangeState(StateMachine.State.Scared);
            }
            else if (parentTag == "Prey")
            {
                stateMachine.ChangeState(StateMachine.State.Scared);   
            }
        }
        
        
    }
}
