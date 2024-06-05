using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private GameObject _pedalBreakOn;
        [SerializeField] private GameObject _pedalBreakOff;
        [SerializeField] private GameObject _pedalGasOn;
        [SerializeField] private GameObject _pedalGasOff;

        private  void OnEnable()
        {
            PedalBreak(false);
            PedalGas(false);
        }

        public void PedalBreak(bool on)
        {
            if (on)
            {
                _pedalBreakOn.SetActive(true);
                _pedalBreakOff.SetActive(false);
            }
            else
            {
                _pedalBreakOn.SetActive(false);
                _pedalBreakOff.SetActive(true);
            }
        }

        public void PedalGas(bool on)
        {
            if (on)
            {
                _pedalGasOn.SetActive(true);
                _pedalGasOff.SetActive(false);
            }
            else
            {
                _pedalGasOn.SetActive(false);
                _pedalGasOff.SetActive(true);
            }
        }
    }

}
