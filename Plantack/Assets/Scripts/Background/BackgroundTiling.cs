using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Background
{
    public class BackgroundTiling : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform[] backgrounds;
        [SerializeField] private float size = 25;

        private float _spaceToUpdateBackground;
        private float _threshold = 1;
        private int _firstBackgroundIndex = 0;
        private int LastBackgroundIndex => _firstBackgroundIndex > 0 ? _firstBackgroundIndex - 1 : backgrounds.Length - 1;



        private void Start()
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");
            Camera mainCamera = Camera.main;
            _spaceToUpdateBackground = mainCamera.orthographicSize * mainCamera.aspect + _threshold;
        }

        private void Update()
        {
            float targetX = target.position.x;
            float firstBackgroundXPos = backgrounds[_firstBackgroundIndex].position.x;
            float lastBackgroundXPos = backgrounds[LastBackgroundIndex].position.x;
            if (firstBackgroundXPos - size / 2 > targetX - _spaceToUpdateBackground)
            {
                Vector3 pos = backgrounds[LastBackgroundIndex].position;
                backgrounds[LastBackgroundIndex].position = new Vector3(firstBackgroundXPos - size, pos.y, pos.z);
                _firstBackgroundIndex = LastBackgroundIndex;
            }else if (lastBackgroundXPos + size / 2 < targetX + _spaceToUpdateBackground)
            {
                Vector3 pos = backgrounds[_firstBackgroundIndex].position;
                backgrounds[_firstBackgroundIndex].position = new Vector3(firstBackgroundXPos + size, pos.y, pos.z);
                _firstBackgroundIndex +=1 ;
                _firstBackgroundIndex %= backgrounds.Length;
            }
        }
    }
}