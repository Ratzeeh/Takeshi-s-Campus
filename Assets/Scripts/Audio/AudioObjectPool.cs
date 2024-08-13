using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioObjectPool<T> where T : MonoBehaviour, IPoolable
{

    Stack<T> availableObjects = new Stack<T>();

    public AudioObjectPool(T _gameObject, int _audioSourceCount, Transform _parentObject)
    {
        for (int i = 0; i < _audioSourceCount; i++)
        {
            var tmp = Object.Instantiate(_gameObject, Vector3.zero, Quaternion.identity, _parentObject);
            //var tmp = Object.Instantiate()

            tmp.GetComponent<IPoolable>().Deactivate = () =>
            {
                tmp.gameObject.SetActive(false);
                tmp.transform.SetParent(_parentObject);
                availableObjects.Push(tmp);
            };

            tmp.gameObject.SetActive(false);
            availableObjects.Push(tmp);
        }
    }

    public T GetObject()
    {
        if (availableObjects.Count > 0)
        {
            var tmp = availableObjects.Pop();
            tmp.gameObject.SetActive(true);
            return tmp;
        }

        return null;
    }
}
