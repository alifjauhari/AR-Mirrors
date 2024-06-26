using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NNCam
{

    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown cameraDropdown;
        [SerializeField] private Slider thresholdSlider;
        [SerializeField] private WebcamInput webcamInput;
        [SerializeField] private Compositor compositor;

        void Start()
        {
            // Populate the dropdown with available webcam devices
            var devices = WebCamTexture.devices;
            cameraDropdown.ClearOptions();
            foreach (var device in devices)
            {
                cameraDropdown.options.Add(new TMP_Dropdown.OptionData(device.name));
            }

            // Set initial slider value
            thresholdSlider.value = compositor.Threshold;

            // Add listeners for UI elements
            cameraDropdown.onValueChanged.AddListener(OnCameraDropdownChanged);
            thresholdSlider.onValueChanged.AddListener(OnThresholdSliderChanged);
        }

        void OnCameraDropdownChanged(int index)
        {
            var devices = WebCamTexture.devices;
            if (index >= 0 && index < devices.Length)
            {
                webcamInput.SetDevice(devices[index].name);
            }
        }

        void OnThresholdSliderChanged(float value)
        {
            compositor.Threshold = value;
        }
    }

} // namespace NNCam
