using UnityEngine;

namespace Gilzoide.CameraViewportRect.Samples.RotatingCube
{
    public class Rotate : MonoBehaviour
    {
        public Vector3 Velocidade = new Vector3(30, 30, 30);

        void Update()
        {
            transform.Rotate(Velocidade * Time.deltaTime);
        }
    }
}
