using UnityEngine;

namespace CropTogether.Input
{
    public class GamerInput : MonoBehaviour
    {
        private static GamerInput _instance;
        private InputControls _inputControls;

        public static InputControls Controls => Instance._inputControls;

        private static GamerInput Instance
        {
            get
            {
                if (_instance == null)
                {
                    var gameObject = new GameObject(nameof(GamerInput));
                    _instance = gameObject.AddComponent<GamerInput>();
                    DontDestroyOnLoad(gameObject);
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
        }

        private void OnDestroy()
        {
            _inputControls?.Dispose();
        }
    }
}