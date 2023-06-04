using UnityEngine;
using Entitas.Unity;
using Entitas;
public class BulletCollision : MonoBehaviour
{
    private Contexts _contexts;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.GetEntityLink().entity.HasComponent(GameComponentsLookup.Enemy))
        {
            _contexts = Contexts.sharedInstance;
            var e = _contexts.game.CreateEntity();
            e.AddCollision(other.gameObject, this.gameObject);
        }
    }
}