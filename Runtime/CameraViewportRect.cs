using UnityEngine;

namespace Gilzoide.CameraViewportRect
{
    [RequireComponent(typeof(RectTransform)), ExecuteAlways]
    public class CameraViewportRect : MonoBehaviour
    {
        [Tooltip("Target Camera")]
        [SerializeField] protected Camera _camera;

        [Tooltip("Toggle Camera.enabled when this script gets enabled/disabled")]
        public bool ToggleCameraEnabled = true;

        public Camera Camera
        {
            get => _camera;
            set
            {
                _camera = value;
                if (isActiveAndEnabled)
                {
                    RefreshCameraRect();
                }
            }
        }

        protected Canvas _canvas;
        protected readonly Vector3[] _worldCorners = new Vector3[4];

        public void RefreshCameraRect()
        {
            if (Camera && _canvas)
            {
                Camera.pixelRect = GetScreenRect();
            }
        }

        protected virtual void Update()
        {
            if (transform.hasChanged)
            {
                transform.hasChanged = false;
                RefreshCameraRect();
            }
        }

        protected virtual void OnEnable()
        {
            _canvas = FindRootCanvas();
            if (ToggleCameraEnabled && Camera)
            {
                Camera.enabled = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (ToggleCameraEnabled && Camera)
            {
                Camera.enabled = false;
            }
        }

        protected virtual void OnTransformParentChanged()
        {
            if (isActiveAndEnabled)
            {
                _canvas = FindRootCanvas();
                RefreshCameraRect();
            }
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (isActiveAndEnabled)
            {
                RefreshCameraRect();
            }
        }
#endif

        protected Rect GetScreenRect()
        {
            ((RectTransform) transform).GetWorldCorners(_worldCorners);

            Vector3 bottomLeft = _worldCorners[0];
            Vector3 topRight = _worldCorners[2];
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera && _canvas.worldCamera != null)
            {
                Camera camera = _canvas.worldCamera;
                bottomLeft = camera.WorldToScreenPoint(bottomLeft);
                topRight = camera.WorldToScreenPoint(topRight);
            }
            return Rect.MinMaxRect(bottomLeft.x, bottomLeft.y, topRight.x, topRight.y);
        }

        protected Canvas FindRootCanvas()
        {
            Canvas canvas = GetComponentInParent<Canvas>();
            return canvas != null ? canvas.rootCanvas : null;
        }
    }
}