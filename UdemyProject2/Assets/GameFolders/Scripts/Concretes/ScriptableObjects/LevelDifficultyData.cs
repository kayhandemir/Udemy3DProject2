using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Controllers;

namespace UdemyProject2.ScriptableObjects
{
    [CreateAssetMenu(menuName ="Create Difficulty/Create New",fileName ="Level Difficulty",order =1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawnersPrefab;
        [SerializeField] Material _skyBoxMetarial;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _addDelayTime = 50f;
        public FloorController FloorPrefabs => _floorPrefab;
        public GameObject SpanwerPrefab => _spawnersPrefab;
        public Material SkyBoxMetarial => _skyBoxMetarial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;
    }
}

