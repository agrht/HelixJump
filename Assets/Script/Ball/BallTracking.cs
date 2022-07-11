using System;
using Script.Tower;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Ball
{
    public class BallTracking : MonoBehaviour
    {
        [SerializeField] private Vector3 directionOffset;
        [SerializeField] private float length;
        
        private Ball _ball;
        private Beam _beam;
        private Vector3 _cameraPosition;
        private Vector3 _minimumBallPosition;

        private void Start()
        {
            _ball = FindObjectOfType<Ball>();
            _beam = FindObjectOfType<Beam>();

            Vector3 position = _ball.transform.position;
            _cameraPosition = position;
            _minimumBallPosition = position;
            
            TrackBall();
        }

        private void Update()
        {
            if (_ball.transform.position.y < _minimumBallPosition.y)
            {
                TrackBall();
                _minimumBallPosition = _ball.transform.position;
            }
        }

        private void TrackBall()
        {
            var ballTransform = _ball.transform;
            Vector3 ballPosition = ballTransform.position;
            Vector3 beamPosition = _beam.transform.position;
            beamPosition.y = ballPosition.y;
            _cameraPosition = ballPosition;
            Vector3 direction = (beamPosition - ballPosition).normalized + directionOffset;
            _cameraPosition -= direction * length;
            transform.position = _cameraPosition;
            transform.LookAt(ballTransform);
        }
    } 
}

