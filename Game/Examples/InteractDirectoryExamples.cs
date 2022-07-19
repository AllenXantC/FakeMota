using Mota.Game.Interact;
using Mota.Game.Interact.InteractManagers;
using Mota.Game.Texts.Role;

namespace Mota.Game.Examples;

public static class InteractDirectoryExamples
{
    private static readonly NameText NameText = new();

    public static readonly InteractDirectory ZbbInDir = new(
        new Queue<InteractMessage>().InitiateQueue(
            new InteractMessage
            (NameText.TextWithLans["Zbb"],
                EInteractManagerType.TalkManager, 0),
            new InteractMessage
            (NameText.TextWithLans["Csb"],
                EInteractManagerType.TalkManager, 0),
            new InteractMessage
            (NameText.TextWithLans["Zbb"],
                EInteractManagerType.BattleManager, 0)),
        NameText.TextWithLans["Zbb"]
    );

    public static readonly InteractDirectory GxqInDir = new(
        new Queue<InteractMessage>().InitiateQueue(
            new InteractMessage
                (NameText.TextWithLans["Gxq"], EInteractManagerType.TalkManager, 0),
            new InteractMessage
                (NameText.TextWithLans["Csb"], EInteractManagerType.TalkManager, 0),
            new InteractMessage
                (NameText.TextWithLans["Gxq"], EInteractManagerType.BattleManager, 0)),
        NameText.TextWithLans["Gxq"]
    );

    public static readonly InteractDirectory KhrushchevDir = new(
        new Queue<InteractMessage>().InitiateQueue(
            new InteractMessage
            (NameText.TextWithLans["Khrushchev"],
                EInteractManagerType.TalkManager, 0),
            new InteractMessage
            (NameText.TextWithLans["Csb"],
                EInteractManagerType.TalkManager, 0),
            new InteractMessage
            (NameText.TextWithLans["Khrushchev"],
                EInteractManagerType.BattleManager, 0)),
        NameText.TextWithLans["Khrushchev"]);
    
    public static readonly InteractDirectory ShopInDir = new(
        new Queue<InteractMessage>().InitiateQueue(
            new InteractMessage
                (NameText.TextWithLans["Shop"], EInteractManagerType.SellManager, 0)),
        NameText.TextWithLans["Shop"]);

    public static readonly InteractDirectory GateInDir = new(
        new Queue<InteractMessage>().InitiateQueue(
            new InteractMessage(NameText.TextWithLans["Gate"], EInteractManagerType.StageChangeManager, 0)),
        NameText.TextWithLans["Gate"]);
        
    private static Queue<T> InitiateQueue<T>(this Queue<T> queue, params T[] elements)
    {
        foreach (var element in elements)
        {
            queue.Enqueue(element);
        }

        return queue;
    }
}