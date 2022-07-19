namespace Mota.Game.Logic;

public static class Driver
{
    private static bool _repeatOK;
    private static readonly AutoResetEvent RepeatAutoResetEvent = new(false);
    // both two booleans control the two threads of repeating
    private static bool _isInteract;
    private static bool _isOpenSettings;
    public static int FrameIntervalMs;
    public static bool IsFinished;

    public static void Drive(Action<char> onGetCommonInput,
        Action<int> onGetIsInteractInput, Action oriUpdate,
        Func<bool> isInteractDetect, Func<bool> interactUpdate,
        Func<bool> isOpenSettingDetect, Func<bool> changeSettings)
    {
        var threadGetInput = new Thread(() =>
        {
            while (true)
            {
                if (_repeatOK)
                {
                    if (IsFinished) return;
                    var input = Console.ReadKey();
                    var ch = input.KeyChar;
                    switch (ch)
                    {
                        case >= 'a' and <= 'z':
                            onGetCommonInput(ch);
                            break;
                        case '1':
                            onGetIsInteractInput(1);
                            break;
                    }
                }
                else
                {
                    RepeatAutoResetEvent.WaitOne();
                }
            }
        });
        var threadRepeatInvoke = new Thread(() =>
        {
            while (true)
            {
                if (_repeatOK)
                {
                    // constantly run oriUpdate and isInteractDetect
                    RepeatInvoke(oriUpdate, FrameIntervalMs,
                        isInteractDetect, isOpenSettingDetect);
                }
                else
                {
                    RepeatAutoResetEvent.WaitOne();
                }
            }
        });
        threadGetInput.Start();
        threadRepeatInvoke.Start();
        while (true)
        {
            try
            {
                RepeatBegin(); // _repeatOK becomes true, two threads start working
                if (!_isInteract && !_isOpenSettings) continue;
                RepeatEnd(); // _repeatOK becomes true, two threads stop
                Thread.Sleep(1000);
                // pause for a second and wait for both threads to actually stop
                if (_isInteract)
                {
                    var taskInteract =
                        Task.Run(() => { _isInteract = interactUpdate(); });
                    taskInteract.Wait();
                }
                else if (_isOpenSettings)
                {
                    var taskChangeSettings =
                        Task.Run(() => { _isOpenSettings = changeSettings(); });
                    taskChangeSettings.Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
        
    private static void RepeatInvoke(Action update, int callIntervalMs, 
        Func<bool> isInteractDetect, Func<bool> isOpenSettingDetect)
    {
        while (true)
        {
            Thread.Sleep(Math.Max(1, callIntervalMs));
            // thread sleeps 1ms at least
            update();
            // update the GameState while updating the game
            GameState.Instance.Update();
            if (!IsFinished)
            {
                _isOpenSettings = isOpenSettingDetect();
                _isInteract = isInteractDetect();
            }
            if (_isInteract || _isOpenSettings) return;
        }
    }

    private static void RepeatBegin()
    {
        _repeatOK = true;
        RepeatAutoResetEvent.Set();
    }

    private static void RepeatEnd()
    {
        _repeatOK = false;
    }
}