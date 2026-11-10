using System.Collections;
using UnityEngine;

namespace LevGamekit.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
