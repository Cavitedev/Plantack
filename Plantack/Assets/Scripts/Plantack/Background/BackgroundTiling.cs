using UnityEngine;

namespace Plantack.Background
{
    public class BackgroundTiling : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform[] backgrounds;
        [SerializeField] private float size = 25;

        private float _spaceToUpdateBackground;
        private float _threshold = 1;
        private int _firstBackgroundIndex;

        private int LastBackgroundIndex =>
            _firstBackgroundIndex > 0 ? _firstBackgroundIndex - 1 : backgrounds.Length - 1;


        private void Start()
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");
            Camera mainCamera = Camera.main;
            _spaceToUpdateBackground = mainCamera.orthographicSize * mainCamera.aspect + _threshold;
        }

        private void Update()
        {
            float targetX = target.position.x;
            Vector3 firstBackgroundPos = backgrounds[_firstBackgroundIndex].position;
            Vector3 lastBackgroundPos = backgrounds[LastBackgroundIndex].position;
            UpdateBackgroundsPos(targetX, firstBackgroundPos, lastBackgroundPos);
        }

        private void UpdateBackgroundsPos(float targetX, Vector3 firstBackgroundPos, Vector3 lastBackgroundPos)
        {
            if (IsTargetTooLeft(firstBackgroundPos.x, targetX))
            {
                MoveLastBackgroundToFirstPos(firstBackgroundPos);
                MoveIndexLeft();
            }
            else if (IsTargetTooRight(lastBackgroundPos.x, targetX))
            {
                MoveFirstBackgroundToLastPos(lastBackgroundPos);
                MoveIndexRight();
            }
        }

        private bool IsTargetTooLeft(float firstBackgroundXPos, float targetX)
        {
            return firstBackgroundXPos - size / 2 > targetX - _spaceToUpdateBackground;
        }
        
        private bool IsTargetTooRight(float lastBackgroundXPos, float targetX)
        {
            return lastBackgroundXPos + size / 2 < targetX + _spaceToUpdateBackground;
        }
        
        private void MoveFirstBackgroundToLastPos(Vector3 lastBackgroundPos)
        {
            backgrounds[_firstBackgroundIndex].position =
                new Vector3(lastBackgroundPos.x + size, lastBackgroundPos.y, lastBackgroundPos.z);
        }

        private void MoveLastBackgroundToFirstPos(Vector3 firstBackgroundPos)
        {
            backgrounds[LastBackgroundIndex].position = new Vector3(firstBackgroundPos.x - size,
                firstBackgroundPos.y, firstBackgroundPos.z);
        }

        private void MoveIndexLeft()
        {
            _firstBackgroundIndex = LastBackgroundIndex;
        }

        private void MoveIndexRight()
        {
            _firstBackgroundIndex += 1;
            _firstBackgroundIndex %= backgrounds.Length;
        }




    }
}