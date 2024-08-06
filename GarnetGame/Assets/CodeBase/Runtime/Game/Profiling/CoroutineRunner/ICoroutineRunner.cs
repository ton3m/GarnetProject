using System.Collections;

namespace CodeBase
{
    public interface ICoroutineRunner
    {
        void StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine);
    }
}