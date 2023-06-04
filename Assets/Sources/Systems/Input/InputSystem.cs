using Entitas;
using UnityEngine;
public class InputSystem : IExecuteSystem, IInitializeSystem
{
    private Contexts _context;
    private IGroup<GameEntity> _group;
    public InputSystem(Contexts context)
    {
        _context = context;
        _group = _context.game.GetGroup(GameMatcher.Player);
    }
    public void Initialize()
    {
        _context.input.SetInput(Vector3.zero);
        
    }
    public void Execute()
    {
        MoveInput();
        ShootInput();
        if (Input.GetKeyDown(KeyCode.H))
        {
            
        }
    }

    private void MoveInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _context.input.ReplaceInput(new Vector3(horizontal, 0f, vertical));
    }
    private void ShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _group.GetSingleEntity().isShoot)
        {
            var e = _context.game.CreateEntity();
            var playerEntity = _group.GetSingleEntity();
            e.AddResource(_context.game.gameSetup.value.pool.bulletPrefab);
            e.isBullet = true;
            
           
        }
    }
}