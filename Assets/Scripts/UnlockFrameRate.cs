using System.Collections;
using System.Threading;
using UnityEngine;

public class UnlockFrameRate : MonoBehaviour
{
    private const int MaxRate = 9999;

    [Header("Frame Settings")] [SerializeField]
    private float targetFrameRate = 60.0f;

    private float _currentFrameTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxRate;
        _currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine(WaitForNextFrame());
    }

    private IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            _currentFrameTime += 1.0f / targetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = _currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < _currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
}