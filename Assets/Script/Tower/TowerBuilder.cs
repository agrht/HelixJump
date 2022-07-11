using Script.Platform;
using UnityEngine;

namespace Script.Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int _levelCount;
        [SerializeField] private float _additioalScale;
        [SerializeField] private GameObject _beam;
        [SerializeField] private SpawnPlatform _startPlatform;
        [SerializeField] private Platform.Platform[] _platform;
        [SerializeField] private FinishPlatform _finishPlatform;

        private float _startAndFinishAdditionalScale= 0.5f;

        public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additioalScale/2f;
    
        private void Awake()
        {
            Build();
        }
        private void Build()
        {
            GameObject beam = Instantiate(_beam,transform);
            beam.transform.localScale = new Vector3(1,BeamScaleY,1);

            Vector3 spawnPosition = beam.transform.position;
            spawnPosition.y += beam.transform.localScale.y - _additioalScale;
            
            SpawnPlatform(_startPlatform,ref spawnPosition,beam.transform);
            for (int i = 0; i < _levelCount; i++)
            {
                SpawnPlatform(_platform[Random.Range(0,_platform.Length)],ref spawnPosition,beam.transform);
            }
            SpawnPlatform(_finishPlatform,ref spawnPosition,beam.transform);
        }

        private void SpawnPlatform(Platform.Platform platform,ref Vector3 spawnPosition, Transform parent)
        {
            Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0,360),0), parent);
            spawnPosition.y -= 1;
        }
    }
}

