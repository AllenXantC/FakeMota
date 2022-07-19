using Mota.Game.AI.ActorAI;
using Mota.Game.Interact;
using Mota.Game.Interact.InteractManagers;
using Mota.Game.Role.Actor;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class InteractController : IUpdate
{
    private InteracterManager _interacterManager;
    private readonly InteractRenderManager _interactRenderManager = new();
    private Player _player;
    private Role.Role _target;
    private PlayerAI _playerAI;
    private AI.AI _targetAI;
    /// <summary>
    /// just for storing the temporary queue that need to be assigned back
    /// </summary>
    private Queue<InteractMessage> _localInteractMessages;
    private List<InteractDirectory> _interactDirectories;
    private Func<bool> _isEnemyAllDie;
    private Action _setStage;

    public void Set(Player player, Role.Role target, List<InteractDirectory> directories,
        Func<bool> isEnemyAllDie, Action setStage)
    {
        Debug.Log($"{GetType().Name} Awake");
        _interactRenderManager.Awake();
        _player = player;
        _target = target;
        _playerAI = _player.AI as PlayerAI;
        _targetAI = _target.AI;
        _interactDirectories = directories;
        _isEnemyAllDie = isEnemyAllDie;
        _setStage = setStage;
    }
        
    public void Update()
    {
        if (_playerAI == null || _targetAI == null) return;
        _localInteractMessages = new Queue<InteractMessage>();
        for (var i = 0; i < _interactDirectories.Count; i++)
            // can't use foreach here since the elements need to be changed
        {
            var interactDirectory = _interactDirectories[i];
            if (interactDirectory.RoleName.ToString() != _target.Name.ToString())
                continue;
            // track the interactDirectory
            do
            {
                var interactMessage = interactDirectory.InteractMessages.Dequeue();
                _interacterManager = GetType().Assembly.CreateInstance
                    ("Mota.Game.Interact.InteractManagers." +
                     $"{interactMessage.EInteractManagerType.ToString()}") 
                    as InteracterManager;
                _interacterManager?.Awake(_isEnemyAllDie, _setStage);
                if (interactMessage.RoleName.Equals(_target.Name))
                    // judge whether the target interacts first
                {
                    _interacterManager?.InteractUpdate(interactMessage, 
                        _player, _target, _interactRenderManager);
                    _interacterManager = null;
                }
                else if (interactMessage.RoleName.Equals(_player.Name))
                {
                    _interacterManager?.InteractUpdate(interactMessage, 
                        _target, _player, _interactRenderManager);
                    _interacterManager = null;
                }
                _localInteractMessages?.Enqueue(interactMessage);
                // the point of putting the interactMessage back into the queue is
                // is that the next time the interact happens, there's something in
                // the queue to be dequeued (avoid exception)
            } while (interactDirectory.InteractMessages.Count != 0);

            interactDirectory.InteractMessages = _localInteractMessages;
            _interactDirectories[i] = interactDirectory;
            _localInteractMessages = null;
            // Empty temporary variables in time to prevent InteractMessages
            // from being overloaded with elements  
        }
    }
}