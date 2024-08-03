using System.Collections;
using UnityEngine;

namespace CodeBase
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private readonly MonoBehaviour _runner;

        public CoroutineRunner(MonoBehaviour runner)
        {
            _runner = runner;
        }

        public new void StartCoroutine(IEnumerator coroutine) => 
            _runner.StartCoroutine(coroutine);

        public new void StopCoroutine(IEnumerator coroutine) => 
            _runner.StopCoroutine(coroutine);
    }
}