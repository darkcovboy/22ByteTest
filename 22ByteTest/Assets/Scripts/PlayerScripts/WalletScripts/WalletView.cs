using TMPro;
using UnityEngine;
using Zenject;

namespace PlayerScripts.WalletScripts
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;
        
        private IMoneyChangedView _wallet;
        
        [Inject]
        public void Constructor(IMoneyChangedView wallet)
        {
            _wallet = wallet;
        }

        private void OnEnable()
        {
            _wallet.OnMoneyChanged += OnMoneyChanged;
        }
        
        private void OnDisable()
        {
            _wallet.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            _moneyText.text = $"{money}";
        }
    }
}